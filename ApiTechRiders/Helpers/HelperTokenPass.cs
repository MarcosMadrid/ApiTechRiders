namespace ApiTechRiders.Helpers
{
    public class HelperTokenPass
    {
        public string GenerarCodigoAsync()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000);
            string codigo = randomNumber.ToString();
            return codigo;
        }
    }
}
