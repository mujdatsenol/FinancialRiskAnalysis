# FinancialRiskAnalysis
This is a financial risk analysis application

### Add Migrations
FinancialRiskAnalysis.Persistence dizini içerisinde aşağıda ki kodu CLI da çalıştırın.

MainDbContext.cs dosyası içerisin de connectionString parametresini set ettiğinizden emin olun (`dotnet ef migrations add` komutunu kullanırken DbContextOptionsBuilder veri tabanı adresini bulamıyor. Farklı yöntemle düzeltilebilir.). Aynı connectionString değerini FinancialRiskAnalysis.Api içerisinde ki appsettings.json içerisine de eklemelisiniz.

`dotnet ef migrations add InitialCreate --output-dir Contexts/Main/Migrations`

### Database Update
FinancialRiskAnalysis.Persistence dizini içerisinde aşağıda ki kodu CLI da çalıştırın.

`dotnet ef database update`

Uygulama çalıştıktan sonra **financial-risk-analysis-ui** dizini içerisinde ki React uygulamasını `npm start` ile çalıştırıp ekranlara erişebilirsiniz.