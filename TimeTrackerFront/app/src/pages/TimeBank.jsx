import { useState, useRef, useEffect } from 'react'
import TimeEntry from '../components/TimeEntry';
import Calendar from '../components/Calendar';
import TimeTrackerController from '../Controllers/TimeTrackerController';
import PopUp from '../components/PopUp';

function TimeBank() {

  const [inputValue, setInputValue] = useState('');
  const [isActivePopup, setIsActivePopup] = useState(false);
  const textareaRef = useRef(null);
  const [timeEntries, setTimeEntries] = useState({
    start: '',
    break: '',
    clockIn: '',
    clockOut: '',
    description: '',
  });


  const [activeOption, setActiveOption] = useState('start');
  const [selectedDate, setSelectedDate] = useState('');

  const controller = new TimeTrackerController();

  const handleOkClick = async () => {
    const currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

    switch (activeOption) {
      case 'start':
        setTimeEntries((prev) => ({ ...prev, start: currentTime }));
        setActiveOption('break');
        break;
      case 'break':
        setTimeEntries((prev) => ({ ...prev, break: currentTime }));
        setActiveOption('clockIn');
        break;
      case 'clockIn':
        setTimeEntries((prev) => ({ ...prev, clockIn: currentTime }));
        setActiveOption('clockOut');
        break;
      case 'clockOut':
        setTimeEntries((prev) => ({ ...prev, clockOut: currentTime }));
        setTimeEntries((prev) => ({ ...prev, dateTraker: selectedDate, }));
        setActiveOption('register');
        textareaRef.current.focus();
        break;
      case 'register': {
        try {
          const value = await controller.registerTimeEntry(timeEntries);

          setIsActivePopup(value);

        } catch (error) {
          setIsActivePopup(error);
        }
        break;
      }

      default:
        break;
    }
  };

  useEffect(() => {

    setTimeEntries((prev) => ({ ...prev, description: inputValue, }));

  }, [inputValue])

  setTimeout(() => {
    if (isActivePopup)
      setIsActivePopup(false);
  }, 5000);


  return (
    <>
      <div className="flex flex-col items-center mt-10">

        <Calendar onDateSelect={setSelectedDate} />

        <TimeEntry timeEntries={timeEntries} activeOption={activeOption} />

        <div className="mt-5 w-full px-4">
          <textarea
            ref={textareaRef}
            value={inputValue}
            onChange={(e) => setInputValue(e.target.value)}
            className="border rounded-2xl w-full h-[150px] bg-[#F3F0F0] placeholder:text-left border-gray-500 pl-3 mt-0 text-left p-2"
            placeholder="Description..."
          />
          <div className='w-full items-end justify-end flex px-9 pb-3'>
            <button
              onClick={handleOkClick}
              className={`${activeOption === 'register'
                ? 'bg-blue-500 text-white rounded-xl p-2'
                : 'mt-2 w-12 h-12 bg-blue-500 text-white rounded-full flex justify-center items-center'
                }`}
            >
              {activeOption === 'register' ? 'Register' : 'OK'}
            </button>
          </div>
        </div>

        {isActivePopup && <PopUp isActive={isActivePopup} />}
      </div>
    </>
  );
}

export default TimeBank;
