სისტემაში ავტორიზაცია ხდება JWT access token-ით. ტოკენის მისაღებად გამოიყენეთ LogIn ენდფოინტი.

1. User LogIn
Endpoint: POST /api/User/LogIn
Request Body:
{
  "userName": "test@example.com",
  "password": "P@ssw0rd!"
}

Response (200 OK):
{
  "accessToken": "<JWT token>"
}
2. Authorize in Swagger

Swagger UI-ში დააკოპირეთ დაბრუნებული accessToken.
დააჭირეთ Authorize ღილაკს (ზედა მარჯვენა კუთხეში).
ჩაწერეთ:
Bearer <accessToken>
და დაადასტურეთ.

3. Subsequent Requests
ამის შემდეგ ყველა დაცულ ენდფოინტზე ([Authorize]) Swagger ავტომატურად დაუმატებს ჰედერს:
Authorization: Bearer <JWT token>
