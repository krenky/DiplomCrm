namespace webapi.Models
{
    public class CustomerHistory
    {
        private int id;
        private string? firstName;
        private string? lastName;
        private string? phone;
        private string? email;
        private string? address;
        private DateTime? birthdate;
        private actionHistory action;

        public int Id { get => id; set => id = value; }
        public int CustomerId { get; set; }
        public string? FirstName { get => firstName; set => firstName = value; }
        public string? LastName { get => lastName; set => lastName = value; }
        public string? Phone { get => phone; set => phone = value; }
        public string? Email { get => email; set => email = value; }
        public string? Address { get => address; set => address = value; }
        public DateTime? Birthdate { get => birthdate; set => birthdate = value; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        //public actionHistory ActionHistory { get; set; }
        public string ActionHistory { get
            {
                return action.ToString();
            }
            set
            {
                switch (value)
                {
                    case "Добавлен":
                        {
                            action = actionHistory.Добавлен;
                        }
                        break;
                    case "Изменен":
                        {
                            action = actionHistory.Изменен;
                        }
                        break;
                    case "Удален":
                        {
                            action = actionHistory.Удален;
                        }
                        break;
                }
            }
        }
    }
    public enum actionHistory
    {
        Добавлен,
        Изменен,
        Удален
    }
}
