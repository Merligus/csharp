using System.Globalization;

namespace Exercicio1.Entities
{
    class Invoice
    {
        public double basicPayment { get; set; }
        public double tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            this.basicPayment = basicPayment;
            this.tax = tax;
        }

        public double TotalPayment
        {
            get { return basicPayment + tax; }
        }

        public override string ToString()
        {
            return $"Basic payment: {basicPayment.ToString("F2", CultureInfo.InvariantCulture)}" +
                $"\nTax: {tax.ToString("F2", CultureInfo.InvariantCulture)}" +
                $"\nTotalPayment: {TotalPayment.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
