import ApiService from '../Services/ApiService';
import TimeTracker from '../Models/TimeTracker';


class TimeTrackerController {
  async registerTimeEntry(timeEntries) {

    const timeEntryModel = new TimeTracker(
      timeEntries.dateTraker,
      timeEntries.start,
      timeEntries.break,
      timeEntries.clockIn,
      timeEntries.clockOut,
      timeEntries.description
    );

    try {
      const result = await ApiService(timeEntryModel);
      
      return result;

    } catch (error) {
      console.error(error);
      throw error;
    }
  }
}

export default TimeTrackerController;
