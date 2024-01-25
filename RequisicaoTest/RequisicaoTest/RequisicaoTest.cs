using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;


namespace RequisicaoTest
{
    public class RequisicaoTest
    {
        public IWebDriver driver { get; private set; }
        public IDictionary<String, Object> vars { get; private set; }
        public IJavaScriptExecutor js { get; private set; }

        public RequisicaoTest()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<String, Object>();
        }

        [Theory]
        [InlineData("10", "Sec. Educacao")]
        [InlineData("40", "NAT")]
        public void CT01R01REQUISICAOCAMPODEPARTAMENTOID10(string idDep, string esperado)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1050, 832);
            driver.FindElement(By.Id("idDepartamento")).Click();
            driver.FindElement(By.Id("idDepartamento")).SendKeys(idDep);

            Thread.Sleep(3000);
            var resultado = driver.FindElement(By.Id("departamento")).GetAttribute("value");
            string veDepartamento = esperado;
            driver.Quit();
            Assert.Equal(resultado, veDepartamento);
        }


        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public void CT03R03RequisicaoQtdItem(string valorEsperado)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1022, 718);
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
            driver.FindElement(By.Id("Quantidade")).Click();
            driver.FindElement(By.Id("Quantidade")).SendKeys(valorEsperado);
            driver.FindElement(By.CssSelector("#BtnInserirItens > span")).Click();
            Thread.Sleep(3000);
            IWebElement tabela = driver.FindElement(By.Id("tabelaItens"));
            IWebElement celula = tabela.FindElement(By.XPath(".//tr[1]/td[3]"));
            string valorEncontrado = celula.Text;
            driver.Quit();

            Assert.Equal(valorEsperado, valorEncontrado);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public void CT04RequisicaoTotal(string id)
        {
            driver.Navigate().GoToUrl("https://splendorous-starlight-c2b50a.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1032);   
            driver.FindElement(By.Id("CodigoProduto")).Click();
            driver.FindElement(By.Id("CodigoProduto")).SendKeys(id);
            driver.FindElement(By.Id("Quantidade")).Click();
            driver.FindElement(By.Id("Quantidade")).SendKeys(id);
            driver.FindElement(By.CssSelector("#BtnInserirItens > span")).Click();
            IWebElement tabela = driver.FindElement(By.Id("tabelaItens"));
            IWebElement celula = tabela.FindElement(By.XPath($".//tr[{id}]/td[6]"));
            string valorEsperado = celula.Text;
            string valorEncontrado = driver.FindElement(By.Id("total")).GetAttribute("value");
            driver.Quit();

            Assert.Equal(valorEsperado, valorEncontrado);
        }
    }
}