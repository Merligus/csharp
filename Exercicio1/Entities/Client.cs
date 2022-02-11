namespace Exercicio1.Entities
{
    class Client
    {
        public string name { get; set; }
        public string email { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Client))
                return false;

            Client other = obj as Client;

            return email.Equals(other.email);
        }

        public override int GetHashCode()
        {
            return email.GetHashCode();
        }
    }
}
