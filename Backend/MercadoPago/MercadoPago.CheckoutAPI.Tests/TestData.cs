using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MercadoPago.CheckoutAPI.Tests
{
    public class TestData
    {
        public static readonly IList<TestCard> TestCards = new List<TestCard>
        {
            // Credit Cards
            new TestCard("Mastercard", "5031755734530604", "123", "11/30"),
            new TestCard("Visa", "4509953566233704", "123", "11/30"),
            new TestCard("American Express", "371180303257522", "123", "11/30"),

            // Debit Cards
            new TestCard("Mastercard", "5287338310253304", "123", "11/30"),
            new TestCard("Visa", "4002768694395619", "123", "11/30")
        };

        // Para probar diferentes resultados de pago hay que completar con uno de los siguientes valores en el campo "card_holder_name" al realizar el pago
        public static readonly IList<string> TestPaymentStatus = new List<string>
        {
            "APRO", // Pago aprobado (DNI) 12345678
            "OTHE", // Rechazado por error general (DNI) 12345678
            "CONT", // Pendiente de pago
            "CALL", // Rechazado con validación para autorizar
            "FUND", // Rechazado por importe insuficiente
            "SECU", // Rechazado por código de seguridad inválido
            "EXPI", // Rechazado debido a un problema de fecha de vencimiento
            "FORM", // Rechazado debido a un error de formulario
            "CARD", // Rechazado por falta de card_number
            "INST", // Rechazado por cuotas invalidas
            "DUPL", // Rechazado por pago duplicado
            "LOCK", // Rechazado por tarjeta deshabilitada
            "CTNA", // Rechazado por tipo de tarjeta no permitida
            "ATTE", // Rechazado debido a intentos excedidos del pin de la tarjet
            "BLAC", // Rechazado por estar en lista negra
            "UNSU", // No soportado
            "TEST"  // Usado para aplicar regla de montos
        };
    }

    public class TestCard
    {
        public TestCard(string? id, string? number, string? securityCode, string? expirationDate)
        {
            Id = id;
            Number = number;
            SecurityCode = securityCode;
            ExpirationDate = expirationDate;
        }

        public string? Id {get; set; }
        public string? Number {get; set; }
        public string? SecurityCode {get; set; }
        public string? ExpirationDate { get; set;  }
    }
}
