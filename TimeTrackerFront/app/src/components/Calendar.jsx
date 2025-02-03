import { useEffect, useState } from 'react'

function Calendar(dateItem) {

  let isDateToday;
  const [currentDate, setCurrentDate] = useState(new Date());

  const daysInMonth = (month, year) => new Date(year, month + 1, 0).getDate();
  const firstDayOfMonth = (month, year) => new Date(year, month, 1).getDay();

  const handlePrevMonth = () => {
    setCurrentDate(
      new Date(currentDate.getFullYear(), currentDate.getMonth() - 1, 1)
    );
  };

  const handleNextMonth = () => {
    setCurrentDate(
      new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, 1)
    );
  };

  const renderDaysOfWeek = () => {
    const days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
    return days.map((day) => (
      <th key={day} className="px-2 text-center text-[#C9C9CB] text-xl">
        {day}
      </th>
    ));
  };

  const renderDaysInMonth = () => {
    const year = currentDate.getFullYear();
    const month = currentDate.getMonth();
    const days = daysInMonth(month, year);
    const firstDay = firstDayOfMonth(month, year);

  

    const calendarDays = [];
    for (let i = 0; i < firstDay; i++) {
      calendarDays.push(
        <td key={`empty-${i}`} className="bg-white"></td>
      );
    }

    for (let day = 1; day <= days; day++) {
      const isToday = day === currentDate.getDate();

      if (isToday)
        isDateToday = isToday;

      calendarDays.push(
        <td key={day} className="py-2 text-center">
          {isToday ? (
            <div className="flex justify-center items-center">
              <div className="w-8 h-8 bg-[#E0EFFF] rounded-full flex items-center justify-center">
                <span className="text-[#007AFF] font-bold">{day}</span>
              </div>
            </div>
          ) : (
            <span>{day}</span>
          )}

        </td>
      );
    }
    
    const rows = [];
    let cells = [];

    calendarDays.forEach((day, i) => {
      if (i % 7 !== 0) {
        cells.push(day);
      } else {
        rows.push(cells);
        cells = [day];
      }
    });

    if (cells.length) {
      rows.push(cells);
    }

    return rows.map((row, i) => <tr key={i}>{row}</tr>);
  };

  useEffect(() => {
    if (isDateToday)
      dateItem.onDateSelect(currentDate.toISOString().split('T')[0]);
  }, [currentDate, dateItem, isDateToday]);

  return (
    <>
      <header className="flex justify-between items-center w-72">
        <button onClick={handlePrevMonth} className="fas fa-heart">
          <img src="/assets/icons/left.svg" alt="Left Arrow" className="w-8 h-8" />
        </button>
        <h2 className="text-3xl">
          {currentDate.toLocaleString("en-US", { month: "long" })}{" "}
          {currentDate.getFullYear()}
        </h2>
        <button onClick={handleNextMonth} className="focus:outline-none">
          <img src="/assets/icons/right.svg" alt="Right Arrow" className="w-8 h-8" />
        </button>
      </header>
      <table className="mt-8 border-0" cellPadding={0} cellSpacing={0}>
        <thead>
          <tr>{renderDaysOfWeek()}</tr>
        </thead>
        <tbody>{renderDaysInMonth()}</tbody>
      </table>
    </>
  );
};

export default Calendar;
