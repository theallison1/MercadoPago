
# Mercado Pago - Backend Checkout API

El proyecto es una API que contiene varios de los endpoints de la [documentación de MercadoPago](https://www.mercadopago.com.ar/developers/es/reference) sin necesidad de usar el SDK.

## 🔦 Requerimientos

- [.NET 8 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)
- [Postman](https://www.postman.com/)
    

## 🏕️ Variables de entorno

Antes de ejecutar el proyecto hay que hacer una copia del archivo appsettings.Template.json, renombrarlo a appsettings.json y configurar los valores faltantes:

Credenciales de aplicación a integrar ([Ver panel](https://www.mercadopago.com.ar/developers/panel/app)): 

`MercadoPago:AccessToken`

`MercadoPago:PublicKey`

Configuracion para generar el Json Web Token:

`Jwt:Issuer` (Para pruebas se puede usar la URL de localhost)

`Jwt:SecretKey` (Un GUID o cualquier cosa escrita con mas de 32 caracteres)


## 🔌 Uso

1 - Ejecutar el proyecto (modificar si es necesario la URL y Puerto en el archivo launchSettings.json)
\
2 - Abrir Postman 
\
3 - Importar la [Coleccion y Entorno](MercadoPago/MercadoPago.CheckoutAPI/Postman)  (solo la primera vez)
\
4 - Ajustar la URL del entorno para que coincida con la del archivo launchSettings.json
\
5 - Ejecutar POST /Auth

#### Para Crear un pago:
1 - Ejecutar POST /CardTokens
\
2 - Ejecutar GET /PaymentMethods/Search
\
3 - Ejecutar POST /Payments

#### Para Crear un cliente y tarjeta al finalizar el pago:
1 - Ejecutar POST /Customers
\
2 - Ejecutar POST /CustomerCards/{{CustomerID}}/Cards

## 📄 Referencias
- [Mercado Pago - CheckoutAPI](https://www.mercadopago.com.ar/developers/es/docs/checkout-api/landing)
- [Mercado Pago - API Reference](https://www.mercadopago.com.ar/developers/es/reference)
####hay algunos cambios de configuraciones y errores de sintaxis .
####preprando una nueva feature para explicar el despligue y paso a PRODUCCION.
