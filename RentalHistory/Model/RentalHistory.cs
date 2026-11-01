using System.Collections.Generic;

namespace CarRentalSystem.RentalHistories.Model
{
    public class RentalHistory
    {
        public List<string> history;

        public RentalHistory()
        {
            history = new List<string>();
        }

        // Adds the message to the in-memory list only.
        // (The original Add() also called Save(); that file operation is now
        //  done by RentalHistoryService.Add() right after this call.)
        public void Add(string msg)
        {
            history.Add(msg);
        }

        public void Clear()
        {
            history.Clear();
        }
    }
}
