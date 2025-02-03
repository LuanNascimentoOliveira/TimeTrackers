
function TimeEntry(inputTime) {

  return (
    <div className="w-full grid grid-cols-2 grid-rows-2 gap-2 mt-7 items-center pl-1">
      <div
        className={`mb-4 col-span-1 row-span-1 p-2 transition-transform duration-700 ease-in-out rounded-full ${inputTime.activeOption === 'start' ? 'bg-[#E0EFFF] text-[#007AFF]' : 'text-black'}`}
      >
        <span>Start: {inputTime.timeEntries.start}</span>
      </div>
      <div
        className={`mb-4 col-span-1 row-span-1 p-2  transition-transform duration-700 ease-in-out rounded-full ${inputTime.activeOption === 'clockIn' ? 'bg-[#E0EFFF] text-[#007AFF]' : 'text-black'}`}
      >
        <span>Clock In: {inputTime.timeEntries.clockIn}</span>
      </div>
      <div
        className={` mb-4 col-span-1 row-span-1 p-2 transition-transform duration-700 ease-in-out rounded-full ${inputTime.activeOption === 'break' ? 'bg-[#E0EFFF] text-[#007AFF]' : 'text-black'}`}
      >
        <span>Break: {inputTime.timeEntries.break}</span>
      </div>
      <div
        className={`mb-4 col-span-1 row-span-1 p-1 transition-transform duration-700 ease-in-out rounded-full ${inputTime.activeOption === 'clockOut' ? 'bg-[#E0EFFF] text-[#007AFF]' : 'text-black'}`}
      >
        <span>Clock Out: {inputTime.timeEntries.clockOut}</span>
      </div>
    </div>
  );
};

export default TimeEntry;
