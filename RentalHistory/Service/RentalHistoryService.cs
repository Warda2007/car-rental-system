using CarRentalSystem.RentalHistories.Model;
using CarRentalSystem.RentalHistories.Repository;

namespace CarRentalSystem.RentalHistories.Service
{
    public class RentalHistoryService
    {
        private RentalHistory history;
        private RentalHistoryRepository historyRepository;

        public RentalHistoryService(RentalHistoryRepository historyRepository)
        {
            this.historyRepository = historyRepository;
            history = new RentalHistory();
        }

        public RentalHistory GetHistory()
        {
            return history;
        }

        public void Load()
        {
            historyRepository.Load(history);
        }

        public void Save()
        {
            historyRepository.Save(history);
        }

        // original RentalHistory.Add: add the message, then Save()
        public void Add(string msg)
        {
            history.Add(msg);
            Save();
        }

        public void Clear()
        {
            history.Clear();
        }
    }
}
