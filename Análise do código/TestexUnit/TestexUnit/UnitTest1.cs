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
            public void CategoriaMotivo()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("categoriaMotivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
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
                    dropdown.FindElement(By.XPath("//option[. = 'Gestão']")).Click();
                }
                driver.FindElement(By.Id("Motivo")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("Motivo"));
                    dropdown.FindElement(By.XPath("//option[. = 'Planejamento']")).Click();
                }
            }
            [Fact]
            public void Departamento()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("1");
                driver.FindElement(By.Id("departamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("2");
                driver.FindElement(By.CssSelector(".grupo2 > span")).Click();
                driver.FindElement(By.Id("departamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("3");
                driver.FindElement(By.Id("departamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("4");
                driver.FindElement(By.Id("departamento")).Click();
            }
            [Fact]
            public void Funcionrio()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).SendKeys("1");
                driver.FindElement(By.CssSelector(".grupo5 > span")).Click();
                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).SendKeys("2");
                driver.FindElement(By.Id("NomeFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("idFuncionario")).SendKeys("3");
                driver.FindElement(By.Id("NomeFuncionario")).Click();
            }
            [Fact]
            public void NumerosCamposID()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("1");
                driver.FindElement(By.CssSelector(".camposPrincipaisLinha1")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("idDepartamento")).SendKeys("2.7");
            }
            [Fact]
            public void NveldePrioridade()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("urgente")).Click();
                driver.FindElement(By.Id("medio")).Click();
                driver.FindElement(By.Id("baixo")).Click();
                driver.FindElement(By.Id("medio")).Click();
                driver.FindElement(By.Id("urgente")).Click();
            }
            [Fact]
            public void Produtos()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("1");
                driver.FindElement(By.Id("DescricaoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("2");
                driver.FindElement(By.Id("DescricaoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
                driver.FindElement(By.Id("DescricaoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("4");
                driver.FindElement(By.CssSelector(".linhaAdicionarItens")).Click();
                driver.FindElement(By.Id("DescricaoProduto")).Click();
            }
            [Fact]
            public void Quantidade()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("CodigoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).SendKeys("3");
            }
            [Fact]
            public void SelecionarCampo()
            {
                driver.Navigate().GoToUrl("https://danieljairton.github.io/Projetos%20SENAI/Almoxarifado/Almoxarifado-main/index.html");
                driver.Manage().Window.Size = new System.Drawing.Size(945, 1012);
                driver.FindElement(By.Id("inpNumero")).Click();
                driver.FindElement(By.Id("idDepartamento")).Click();
                driver.FindElement(By.Id("departamento")).Click();
                driver.FindElement(By.Id("dataRequisicao")).Click();
                driver.FindElement(By.Id("idFuncionario")).Click();
                driver.FindElement(By.Id("NomeFuncionario")).Click();
                driver.FindElement(By.Id("cargo")).Click();
                driver.FindElement(By.Id("categoriaMotivo")).Click();
                driver.FindElement(By.Id("Motivo")).Click();
                driver.FindElement(By.Id("DescricaoProduto")).Click();
                driver.FindElement(By.Id("CodigoProduto")).Click();
            }
            [Fact]
            public void CT09_RetanguloVermelho()
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
            public void CT09_RetanguloVerde()
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
            public void CT09_RetanguloAmarelo()
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