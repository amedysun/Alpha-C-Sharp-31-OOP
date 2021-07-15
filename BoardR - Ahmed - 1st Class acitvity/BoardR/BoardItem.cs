using System;
namespace BoardR
{
    public class BoardItem
    {
        private const byte minTitleLenght = 5;
        private const byte maxTitleLenght = 30;

        private string title;
        private DateTime dueDate;
        private Status status;

         public BoardItem(string title, DateTime dueDate)
         {
            this.title = title;
            this.dueDate = dueDate;
            this.status = Status.Open;
         }

        public string Title
        {
            get => this.title;
            private set
            {
                if (string.IsNullOrEmpty(value) || !(value.Length >= minTitleLenght && value.Length <= maxTitleLenght))
                {
                    throw new ArgumentException("Invalid title!");
                }

                this.title = value;
            }
        }

        public DateTime DueDate
        {
            get => this.dueDate;
            private set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("The Due Date cannot be with Past Value");
                }
                this.dueDate = value;
            }
        }

        public Status Status => this.status;

        public void RevertStatus()
        {
            MoveStatusBackward();
        }
        public void MoveStatusBackward()
        {
            if (this.status > Status.Open)
            {
                this.status--;
            }
        }
        public void AdvanceStatus()
        {
            MoveStatusForward();
        }

        public void MoveStatusForward()
        {
            if (this.status < Status.Verified)
            {
                this.status++;
            }
        }

        public string ViewInfo()
        {
            return $"'{this.Title}', [{this.Status}|{this.DueDate.ToString("dd-MM-yyyy")}]";
        }
    }
}
