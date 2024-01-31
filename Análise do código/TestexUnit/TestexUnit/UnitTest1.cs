using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;
using System.Reflection.Metadata;

namespace TestexUnit
{
    public class UnitTest1
    {

        //teste feito por: Mário César
        //Versão do OpenQA.Selenium.Chrome.ChromeDriverExtension: 1.2.0
        //Versão do Selenium.WebDriver.ChromeDriver: 121.0.6167.8500
        //Versão do .NET: 6.0(suporte a longo prazo)
        public class SuiteTests : IDisposable
        {
            public IWebDriver driver { get; private set; }
            public IDictionary<String, Object> vars { get; private set; }
            public IJavaScriptExecutor js { get; private set; }
            public SuiteTests()
            {
                driver = new ChromeDriver();
                js = (IJavaScriptExecutor)driver;
                vars = new Dictionary<String, Object>();
            }
            public void Dispose()
            {
                driver.Quit();
            }
            [Fact]
            public void CT01_RN01_CamposObrigatrios()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.CssSelector("#btnGravar > span")).Click();
                driver.FindElement(By.CssSelector(".conteudo")).Click();
                var resultadoDepartamento = driver.FindElement(By.Id("departamento")).GetAttribute("style");
                var resultadoID = driver.FindElement(By.Id("idDepartamento")).GetAttribute("style");
                var resultadoCargo = driver.FindElement(By.Id("cargo")).GetAttribute("style");
                var resultadoNomeFuncionario = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("style");
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Contains("red", resultadoDepartamento);
                Assert.Contains("red", resultadoID);
                Assert.Contains("red", resultadoCargo);
                Assert.Contains("white", resultadoNomeFuncionario);


            }
            [Fact]
            public void CT01_RN02_SelecionarCampos()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("inpNumero")).Click();
                string inpNumeroResultado = driver.FindElement(By.Id("inpNumero")).GetAttribute("style");
                driver.FindElement(By.Id("idDepartamento")).Click();
                string idDepartamentoResultado = driver.FindElement(By.Id("idDepartamento")).GetAttribute("style");
                driver.FindElement(By.Id("departamento")).Click();
                string departamentoResultado = driver.FindElement(By.Id("departamento")).GetAttribute("style");
                driver.FindElement(By.Id("dataRequisicao")).Click();
                string dataRequisicaoResultado = driver.FindElement(By.Id("dataRequisicao")).GetAttribute("style");
                driver.FindElement(By.Id("idFuncionario")).Click();
                string idFuncionarioResultado = driver.FindElement(By.Id("idFuncionario")).GetAttribute("style");
                driver.FindElement(By.Id("NomeFuncionario")).Click();
                string NomeFuncionarioResultado = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("style");
                driver.FindElement(By.Id("cargo")).Click();
                string cargoResultado = driver.FindElement(By.Id("cargo")).GetAttribute("style");
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                string categoriaMotivoResultado = driver.FindElement(By.Id("categoriaMotivo")).GetAttribute("style");
                driver.FindElement(By.Id("Motivo")).Click();
                string MotivoResultado = driver.FindElement(By.Id("Motivo")).GetAttribute("style");
                driver.FindElement(By.Id("DescricaoProduto")).Click();
                string DescricaoProdutoResultado = driver.FindElement(By.Id("DescricaoProduto")).GetAttribute("style");
                driver.FindElement(By.Id("CodigoProduto")).Click();
                string CodigoProdutoResultado = driver.FindElement(By.Id("CodigoProduto")).GetAttribute("style");
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Contains("lightgreen", inpNumeroResultado);
                Assert.Contains("lightgreen", idDepartamentoResultado);
                Assert.Contains("lightgreen", departamentoResultado);
                Assert.Contains("lightgreen", dataRequisicaoResultado);
                Assert.Contains("lightgreen", idFuncionarioResultado);
                Assert.Contains("lightgreen", NomeFuncionarioResultado);
                Assert.Contains("lightgreen", cargoResultado);
                Assert.Contains("lightgreen", categoriaMotivoResultado);
                Assert.Contains("lightgreen", MotivoResultado);
                Assert.Contains("lightgreen", DescricaoProdutoResultado);
                Assert.Contains("lightgreen", CodigoProdutoResultado);



            }
            [Fact]
            public void CT01_RN03_NumerosCamposID()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("1");
                string idResultado1 = driver.FindElement(By.Id("idDepartamento")).GetAttribute("value");
                driver.FindElement(By.Id("idDepartamento")).Clear();
                driver.FindElement(By.CssSelector(".camposPrincipaisLinha1")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("2.7");
                string idResultado2 = driver.FindElement(By.Id("idDepartamento")).GetAttribute("value");
                Thread.Sleep(3000);
                driver.Quit();

                Assert.IsType<int>(Convert.ToInt32(idResultado1));
                Assert.IsType<int>(Convert.ToInt32(idResultado2));
            }
            [Fact]
            public void CT02_RN04_CategoriaMotivoDados()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("Motivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Planejamento']")).Click();
                    string motivoResultado1 = driver.FindElement(By.Id("Motivo")).GetAttribute("innerText");
                    Assert.NotNull(motivoResultado1);
                }
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Cliente']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("Motivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Quebra de máquinas']")).Click();
                    string motivoResultado2 = driver.FindElement(By.Id("Motivo")).GetAttribute("innerText");
                    Assert.NotNull(motivoResultado2);
                }
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                driver.FindElement(By.Id("Motivo")).Click();
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("Motivo"));
                    dropdown.FindElement(By.XPath("//option[. = '']")).Click();
                    string motivoResultado3 = driver.FindElement(By.Id("Motivo")).GetAttribute("innerText");
                    Assert.NotNull(motivoResultado3);
                }
                Thread.Sleep(3000);
                driver.Quit();

            }
            [Fact]
            public void CT02_RN05_CategoriaMotivo()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("Motivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Planejamento']")).Click();
                    string motivoResultado1 = driver.FindElement(By.Id("Motivo")).GetAttribute("innerText");
                    Assert.Contains("Planejamento", motivoResultado1);
                }
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Cliente']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("Motivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Quebra de máquinas']")).Click();
                    string motivoResultado2 = driver.FindElement(By.Id("Motivo")).GetAttribute("innerText");
                    Assert.Contains("Quebra de máquinas", motivoResultado2);
                }
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                driver.FindElement(By.Id("Motivo")).Click();
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'RP']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("Motivo"));
                    dropdown.FindElement(By.XPath("//option[. = '']")).Click();
                    string motivoResultado3 = driver.FindElement(By.Id("Motivo")).GetAttribute("innerText");
                    string motivoResultado4 = driver.FindElement(By.Id("Motivo")).GetProperty("disabled");
                    Assert.Contains("", motivoResultado3);
                    Assert.Contains("True", motivoResultado4);
                }
                Thread.Sleep(3000);
                driver.Quit();

            }
            [Fact]
            public void CT03_RN06_Departamento()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("1");
                string departamentoResultado1 = driver.FindElement(By.Id("departamento")).GetAttribute("value");
                driver.FindElement(By.Id("idDepartamento")).Clear();
                driver.FindElement(By.Id("departamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("2");
                driver.FindElement(By.CssSelector(".grupo2 > span")).Click();
                driver.FindElement(By.Id("departamento")).Click();
                string departamentoResultado2 = driver.FindElement(By.Id("departamento")).GetAttribute("value");
                driver.FindElement(By.Id("idDepartamento")).Clear();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("3");
                driver.FindElement(By.Id("departamento")).Click();
                string departamentoResultado3 = driver.FindElement(By.Id("departamento")).GetAttribute("value");
                driver.FindElement(By.Id("idDepartamento")).Clear();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("4");
                string departamentoResultado4 = driver.FindElement(By.Id("departamento")).GetAttribute("value");
                driver.FindElement(By.Id("departamento")).Click();
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Equal("Sec. do Trabalho", departamentoResultado1);
                Assert.Equal("Sec. da Educação", departamentoResultado2);
                Assert.Equal("Nat", departamentoResultado3);
                Assert.Equal("", departamentoResultado4);
            }
            [Fact]
            public void CT04_RN07_Funcionario()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).SendKeys("1");
                string funcionarioResultado1 = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("value");
                driver.FindElement(By.Id("idFuncionario")).Clear();
                driver.FindElement(By.CssSelector(".grupo5 > span")).Click();
                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).SendKeys("2");
                string funcionarioResultado2 = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("value");
                driver.FindElement(By.Id("idFuncionario")).Clear();
                driver.FindElement(By.Id("NomeFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).SendKeys("3");
                string funcionarioResultado3 = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("value");
                driver.FindElement(By.Id("idFuncionario")).Clear();
                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).SendKeys("4");
                string funcionarioResultado4 = driver.FindElement(By.Id("NomeFuncionario")).GetAttribute("value");
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Equal("João Vargas", funcionarioResultado1);
                Assert.Equal("Maria Souza", funcionarioResultado2);
                Assert.Equal("André Santos", funcionarioResultado3);
                Assert.Equal("", funcionarioResultado4);
            }
            [Fact]
            public void CT05_RN08_Produtos()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
                string produtoResultado1 = driver.FindElement(By.Id("DescricaoProduto")).GetAttribute("value");
                string estoqueResultado1 = driver.FindElement(By.Id("Estoque")).GetAttribute("value");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("2");
                string produtoResultado2 = driver.FindElement(By.Id("DescricaoProduto")).GetAttribute("value");
                string estoqueResultado2 = driver.FindElement(By.Id("Estoque")).GetAttribute("value");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
                string produtoResultado3 = driver.FindElement(By.Id("DescricaoProduto")).GetAttribute("value");
                string estoqueResultado3 = driver.FindElement(By.Id("Estoque")).GetAttribute("value");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("4");
                string produtoResultado4 = driver.FindElement(By.Id("DescricaoProduto")).GetAttribute("value");
                string estoqueResultado4 = driver.FindElement(By.Id("Estoque")).GetAttribute("value");
                Thread.Sleep(3000);
                driver.Quit();



                Assert.Equal("Papel A4", produtoResultado1);
                Assert.Equal("10", estoqueResultado1);
                Assert.Equal("Mel doce", produtoResultado2);
                Assert.Equal("5", estoqueResultado2);
                Assert.Equal("Cadeira", produtoResultado3);
                Assert.Equal("3", estoqueResultado3);
                Assert.Equal("", produtoResultado4);
                Assert.Equal("", estoqueResultado4);
            }
            [Fact]
            public void CT06_RN09_Quantidade()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
                string quantidadeResultado1 = driver.FindElement(By.Id("Quantidade")).GetProperty("disabled");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("2");
                string quantidadeResultado2 = driver.FindElement(By.Id("Quantidade")).GetProperty("disabled");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
                string quantidadeResultado3 = driver.FindElement(By.Id("Quantidade")).GetProperty("disabled");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("4");
                string quantidadeResultado4 = driver.FindElement(By.Id("Quantidade")).GetProperty("disabled");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Contains("False", quantidadeResultado1);
                Assert.Contains("False", quantidadeResultado2);
                Assert.Contains("False", quantidadeResultado3);
                Assert.Contains("True", quantidadeResultado4);
            }
            [Fact]
            public void CT06_RN10_QuantidadeValores()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
                driver.FindElement(By.Id("Quantidade")).SendKeys("10");
                string quantidadeResultado1 = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("Quantidade")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("2");
                driver.FindElement(By.Id("Quantidade")).SendKeys("10");
                string quantidadeResultado2 = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("Quantidade")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
                driver.FindElement(By.Id("Quantidade")).SendKeys("10");
                string quantidadeResultado3 = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("Quantidade")).Clear();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("4");
                driver.FindElement(By.Id("Quantidade")).SendKeys("-10");
                string quantidadeResultado4 = driver.FindElement(By.Id("Quantidade")).GetAttribute("value");
                driver.FindElement(By.Id("CodigoProduto")).Clear();
                driver.FindElement(By.Id("Quantidade")).Clear();
                Thread.Sleep(3000);
                driver.Quit();

                Assert.True(Convert.ToInt32(quantidadeResultado1) > 0);
                Assert.True(Convert.ToInt32(quantidadeResultado2) > 0);
                Assert.True(Convert.ToInt32(quantidadeResultado3) > 0);
                Assert.True(Convert.ToInt32(quantidadeResultado4) > 0);
            }
            [Fact]
            public void CT07_RN11_BotaoGravar()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
                var resultado = driver.FindElement(By.Id("btnGravar")).GetAttribute("style");
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Contains("none", resultado);
            }
            [Fact]
            public void CT09_RN13_RetanguloVermelho()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
                var resultado = driver.FindElement(By.Id("vermelho")).GetAttribute("style");
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Contains("inline", resultado);
            }
            [Fact]
            public void CT09_RN13_RetanguloVerde()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
                var resultado = driver.FindElement(By.Id("verde")).GetAttribute("style");
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Contains("inline", resultado);
            }
            [Fact]
            public void CT09_RN13_RetanguloAmarelo()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);

                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("2");
                var resultado = driver.FindElement(By.Id("amarelo")).GetAttribute("style");
                Thread.Sleep(3000);
                driver.Quit();

                Assert.Contains("inline", resultado);
            }
        }
    }
    

    
}