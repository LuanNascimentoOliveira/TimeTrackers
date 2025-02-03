class TimeTracker {
    constructor(timeDate, startTime, breakTime, clockIn, clockOut, description) {
        this.timeData = timeDate;
        this.startTime = startTime;
        this.breakTime = breakTime;
        this.clockIn = clockIn;
        this.clockOut = clockOut;
        this.description = description;
    }
}

export default TimeTracker;