Teste desafio DBServer

Automação de Testes para a loja virtual My Store (http://automationpractice.com/index.php)

Tecnologias escolhidas para cumprir o desafio:

  . Selenium WebDriver (Chrome (chromedriver.exe) e Firefox (geckodriver.exe));
  . Visual Studio Community 2017 (C#);
  . .NET Core 2.0;
  . .NET Standard 2.0;
  . xUnit;

A solução:

  TestesDBServer.sln, constitui-se de dois projetos:
  
  Selenium.Util -> Biblioteca de classes, baseada na .NET Standard, que visa simplificar o uso do Selenium nos projetos de teste.
  
  MyStore.Testes -> A automação dos testes, baseada em XUnit (.NET Core), de compra completa a ser realizada no site My Store (http://automationpractice.com/index.php).

  Ambos os projetos utilizam o pacote NuGet Selenium.WebDriver.
  
Selenium.Util:

  Browser.cs -> Enum Browser Indica os browsers que poderam ser utilizados nos testes.
  WebDriverFactory.cs -> Retorna a instância específica para cada tipo de browser utilizado.
  WebDriverExtensions.cs -> Contém os métodos que simplificam as interações com os elementos da página Web.

MyStore.Testes:

  MyStorePage.cs -> Encapsulamento da página web (Page Object);
  MyStorePageMap.cs -> Aqui coloquei a identificação dos elementos da página para acessá-los nos testes;
  MyStorePageTests.cs -> Onde se encontra o método Compra_Completa com os atributos [Theory] e [ClassData];
  MyStoreTestData.cs -> Classe que retorna a massa de dados de teste para o método Compra_Completa;
  PersonalInfo.cs -> Encapsulamento das informações pessoais utilizadas no cadastro de conta no site MyStore;

Configuração:

  appsettings.json -> Arquivo com as configurações necessárias para executar os scripts. (MyStore.Testes\bin\Debug\netcoreapp2.1\)
                      Deve ser modificado para apontar para os WebDrivers do FireFox e Chrome. Segue o conteúdo em minha máquina:
  {
    "Selenium": {
      "CaminhoDriverFirefox": "C:\\Selenium\\FirefoxDriver\\",
      "CaminhoDriverChrome": "C:\\Selenium\\ChromeDriver\\",
      "UrlMyStore": "http://automationpractice.com/index.php"
    }
  }
  
Créditos:

Este trabalho foi realizado tomando como base os artigos escritos por:

  . Renato Groffe (https://medium.com/@renato.groffe/testando-aplica%C3%A7%C3%B5es-web-com-selenium-webdriver-net-core-2-0-net-standard-2-0-e-xunit-b85bd8713933);
  . Hamid Mosalla (http://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/);

Observações sobre a abrangência dos testes:

  Observando o comportamento do site MyStore é possível observar que há vários caminhos diferentes para se concluir uma compra.
  Os métodos e casos de teste desenvolvidos neste exercício estão longe de cobrir essas possibilidades.
  A continuação deste trabalho deve ser minuncioso, deve desenvolver outros métodos de teste para cobrir o máximo de caminhos possível para se completar uma compra.
  Deve-se pensar também nos casos negativos, na soma dos valores dos produtos, nos valores extremos, exceções, timeouts, etc.
  
