using System;
using CarRentalSystem.RentalHistories.Model;
using CarRentalSystem.RentalHistories.Service;

namespace CarRentalSystem.RentalHistories.UI
{
    public class RentalHistoryUI
    {
        private RentalHistoryService historyService;

        public RentalHistoryUI(RentalHistoryService historyService)
        {
            this.historyService = historyService;
        }

        // original viewHistory() -> history.Show()
        public void Show()
        {
            RentalHistory history = historyService.GetHistory();

            Console.Write("\n--- HISTORY ---\n");
            for (int i = 0; i < history.history.Count; i++)
            {
                Console.Write(history.history[i]);
                Console.WriteLine();
            }
        }
    }
}
