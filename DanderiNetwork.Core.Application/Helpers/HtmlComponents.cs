

namespace DanderiNetwork.Core.Application.Helpers
{
    public static class HtmlComponents
    {
        public static string BodyEmail(string verificationuri)
        {
            

            string emailBody = $@"
<!DOCTYPE html>
<html>
<head>
  <style>
    body {{
      font-family: Arial, sans-serif;
      background-color: #f9f9f9;
      margin: 0;
      padding: 20px;
    }}
    .container {{
      max-width: 600px;
      margin: 0 auto;
      background-color: #fff;
      padding: 20px;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }}
    h1 {{
      color: #333;
      text-align: center;
      margin-top: 0;
    }}
    .button {{
      display: inline-block;
      background-color: #3c8dbc;
      color: #fff;
      text-decoration: none;
      padding: 10px 20px;
      border-radius: 4px;
      margin-top: 20px;
    }}
  </style>
</head>
<body>
  <div class=""container"">
    <h1>¡Hola!</h1>
    <p>Please confirm your account visiting this URL:</p>
    <a href=""{verificationuri}"" class=""button"">Confirm email</a>
  </div>
</body>
</html>";

            return emailBody;

        }
    }
}
