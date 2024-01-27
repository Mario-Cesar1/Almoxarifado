
const buttonClick = document.getElementById("btnGravar")

buttonClick.addEventListener("click", function(){
    console.log("Clicou em gravar");
    const objIdDep = document.getElementById("idDepartamento");
    const objNomeDep = document.getElementById("departamento");
    const objData = document.getElementById("dataRequisicao");
    
    const campos = document.querySelectorAll('[data-obrigatorio="true"]')

    let temCampoVazio = false;

    campos.forEach(function(itemElemento){
        console.log(itemElemento.value)

        if (itemElemento.value == "") {
            itemElemento.style.backgroundColor="red";
            temCampoVazio = true;
        } else{
            itemElemento.style.backgroundColor="white";

        }
    })

    if (temCampoVazio) {
        return;
    }

    console.log("final do gravar");


})

function adicionarCorFundoAofocar(){
    const inputs = document.querySelectorAll('input,select')
   
    inputs.forEach(function (itemElemento){
        itemElemento.addEventListener('focus', function(){
            itemElemento.style.backgroundColor="green";
            itemElemento.style.color="white"
        })

        itemElemento.addEventListener('blur', function(){
            itemElemento.style.backgroundColor="white";
            itemElemento.style.color="black"
        })
    })
}

function adicionartCampoAceitarSomenteInteiro(){
    const campos = document.querySelectorAll('[data-soInteiroPositivo="true"]')
    campos.forEach(function(item){

        const teclasAceitas = [48,49,50,51,52,53,54,55,56,57,96,97,98,99,100,101,102,103,104,105]
        item.addEventListener('keyup', function(e){
            if (!teclasAceitas.includes(e.keyCode)) {
                item.value="";
            }
        })
    })
}

function carregarCategoria(){
    const elementCategoria = document.getElementById("categoriaMotivo");
    categorias.forEach(function (objCat){
        let opt = document.createElement('option')
        opt.text = objCat.Descricao;
        opt.value = objCat.idCategoria;
        elementCategoria.appendChild(opt);
    })
}

function carregarMotivoAoAlterarCategoria(){
    const elementCategoria = document.getElementById("categoriaMotivo");

    elementCategoria.addEventListener("change", function(){
        let valorEscolhido = elementCategoria.value;
        const motivosFiltrados = motivos.filter((obj)=> obj.idCategoria==valorEscolhido)

        const elementMotivo = document.getElementById("Motivo");
        elementMotivo.innerHTML = "";
        motivosFiltrados.forEach(function(item){
            let opt = document.createElement('option');
            opt.text = item.Descricao;
            opt.value = item.idMotivo;
            elementMotivo.appendChild(opt);
        })
    })
}

function carregarNomeDepartamentoAoAlterarIDDep(){
    const elementIdDep = document.getElementById("idDepartamento")
    elementIdDep.addEventListener("keyup", function(){
        const valorPesquisar = elementIdDep.value
        const departamentoEncontrado = departamentos.find((dep) => dep.Codigo==valorPesquisar)

        if (departamentoEncontrado!=undefined) {
            document.getElementById("departamento").value=departamentoEncontrado.Descricao;
        }else{
            document.getElementById("departamento").value="";
        }
    })
}


function carregarNomeFuncionarioAoAlterarIDDep(){
    const elementIdFun = document.getElementById("idFuncionario")
    elementIdFun.addEventListener("keyup", function(){
        const valorPesquisar = elementIdFun.value
        const funcionarioEncontrado = funcionarios.find((dep) => dep.idFunc==valorPesquisar)
        console.log(funcionarioEncontrado)
        if (funcionarioEncontrado!=undefined) {
            document.getElementById("NomeFuncionario").value=funcionarioEncontrado.Responsavel;
            document.getElementById("cargo").value=funcionarioEncontrado.idCargo;

        }else{
            document.getElementById("NomeFuncionario").value="";
            document.getElementById("cargo").value="";

        }
    })
}

carregarCategoria();
adicionarCorFundoAofocar();
adicionartCampoAceitarSomenteInteiro();
carregarMotivoAoAlterarCategoria();
carregarNomeDepartamentoAoAlterarIDDep();
carregarNomeFuncionarioAoAlterarIDDep();