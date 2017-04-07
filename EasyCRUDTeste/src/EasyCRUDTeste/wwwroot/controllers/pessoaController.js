var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    $scope.experiencias = [];

    // Autocompletes
    var opcoesHorario = [
        "8:00 as 12:00",
        "13:00 as 18:00",
        "19:00 as 22:00",
        "22 em diante",
    ];
    $scope.horarios = opcoesHorario;
    $scope.horariosselecionado = null;

    var opcoesDisponibilidade = [
    "Até 4 horas",
    "de 4 a 6 horas",
    "de 6 a 8 horas",
    "Apenas finais de semana",
    ];
    $scope.disponibilidades = opcoesDisponibilidade;
    $scope.disponibilidadesselecionado = null;

    var opcoesTipoConta = [
    "Corrente",
    "Poupança",
    ];
    $scope.tipocontas = opcoesTipoConta;
    $scope.tipocontaselecionado = null;

    var Nivel = [
    "0",
    "1",
    "2",
    "3",
    "4",
    "5",
    ];
    $scope.niveis = Nivel;
    $scope.nivelselecionado = null;





    //Gravar
    $scope.GravarPessoa = function () {
        var Action = $("#btnSave").attr("type");
        if (Action == "submit") {
            $scope.Pessoa = {};
            $scope.Pessoa.Nome = $scope.F_Nome;
            $scope.Pessoa.Email = $scope.F_Email;
            $scope.Pessoa.Telefone = $scope.F_Telefone;
            $scope.Pessoa.Idade = $scope.F_Idade;
            $scope.Pessoa.Skype = $scope.F_Skype;
            $scope.Pessoa.Cidade = $scope.F_Cidade;
            $scope.Pessoa.Estado = $scope.F_Estado;
            $scope.Pessoa.Portfolio = $scope.F_Portfolio;
            $scope.Pessoa.NomeBanco = $scope.F_NomeBanco;
            $scope.Pessoa.CPF = $scope.F_CPF;
            $scope.Pessoa.NomePessoaBanco = $scope.F_NomePessoaBanco;
            $scope.Pessoa.TipoConta = $scope.tipocontasselecionado;
            $scope.Pessoa.Agencia = $scope.F_Agencia;
            $scope.Pessoa.NrConta = $scope.F_NrConta;
            $scope.Pessoa.OPConta = $scope.F_OPConta;
            $scope.Pessoa.Disponibilidade = $scope.disponibilidadesselecionado;
            $scope.Pessoa.Horario = $scope.horariosselecionado;
            $scope.Pessoa.Experiencia = $scope.experiencias;
            $scope.Pessoa.IdPessoa = $scope.F_IdPessoa;
            $http.post("/Pessoa/GravarPessoa", $scope.Pessoa
            ).then(function (response) {
                $('#myModal').modal('toggle');
                if (response.data == "Sucesso") {
                    $('#MensagemErro').hide();
                    $('#MesagemEditar').hide();
                    $('#MensagemDeletar').hide();
                    $('#MensagemSucesso').show();
                } else {
                    $('#MensagemErro').show();
                    ('#MensagemSucesso').hide();
                    $('#MesagemEditar').hide();
                    $('#MensagemDeletar').hide();
                }
                $scope.BuscarPessoa();
                $scope.F_Email = "";
                $scope.F_Nome = "";
                $scope.F_Telefone = "";
                $scope.F_Idade = "";
                $scope.F_Skype = "";
                $scope.F_Cidade = "";
                $scope.F_Estado = "";
                $scope.F_Portfolio = "";
                $scope.F_NomeBanco = "";
                $scope.F_CPF = "";
                $scope.F_NomePessoaBanco = "";
                $scope.tipocontasselecionado.tag = "";
                $scope.F_Agencia = "";
                $scope.F_NrConta = "";
                $scope.F_OPConta = "";
                $scope.disponibilidadesselecionado.tag = null;
                $scope.horariosselecionado.tag = null;
                $scope.experiencias = "";
            })
        } else {
            $scope.Pessoa = {};
            $scope.Pessoa.Nome = $scope.F_Nome;
            $scope.Pessoa.Email = $scope.F_Email;
            $scope.Pessoa.Telefone = $scope.F_Telefone;
            $scope.Pessoa.Idade = $scope.F_Idade;
            $scope.Pessoa.Skype = $scope.F_Skype;
            $scope.Pessoa.Cidade = $scope.F_Cidade;
            $scope.Pessoa.Estado = $scope.F_Estado;
            $scope.Pessoa.Portfolio = $scope.F_Portfolio;
            $scope.Pessoa.NomeBanco = $scope.F_NomeBanco;
            $scope.Pessoa.CPF = $scope.F_CPF;
            $scope.Pessoa.NomePessoaBanco = $scope.F_NomePessoaBanco;
            $scope.Pessoa.TipoConta = $scope.tipocontasselecionado;
            $scope.Pessoa.Agencia = $scope.F_Agencia;
            $scope.Pessoa.NrConta = $scope.F_NrConta;
            $scope.Pessoa.OPConta = $scope.F_OPConta;
            $scope.Pessoa.Disponibilidade = $scope.disponibilidadesselecionado;
            $scope.Pessoa.Horario = $scope.horariosselecionado;
            $scope.Pessoa.Experiencia = $scope.experiencias;
            $scope.Pessoa.IdPessoa = $scope.F_IdPessoa;
            $http.post("/Pessoa/AlterarPessoa", $scope.Pessoa
                ).then(function (response) {
                    $('#myModal').modal('toggle');
                    if (response.data == "Sucesso") {
                        $('#MensagemErro').hide();
                        $('#MensagemSucesso').hide();
                        $('#MesagemEditar').show();
                        $('#MensagemDeletar').hide();
                    } else {
                        $('#MensagemSucesso').hide();
                        $('#MesagemEditar').hide();
                        $('#MensagemErro').show();
                        $('#MensagemDeletar').hide();
                    }
                    $scope.BuscarPessoa();
                    $scope.F_Email = "";
                    $scope.F_Nome = "";
                    $scope.F_Telefone = "";
                    $scope.F_Idade = "";
                    $scope.F_Skype = "";
                    $scope.F_Cidade = "";
                    $scope.F_Estado = "";
                    $scope.F_Portfolio = "";
                    $scope.F_NomeBanco = "";
                    $scope.F_CPF = "";
                    $scope.F_NomePessoaBanco = "";
                    $scope.tipocontasselecionado = null;
                    $scope.F_Agencia = "";
                    $scope.F_NrConta = "";
                    $scope.F_OPConta = "";
                    $scope.disponibilidadesselecionado = null;
                    $scope.horariosselecionado.tag = null;
                    $scope.experiencias = "";
                    $scope.F_IdPessoa = "";
                    document.getElementById("btnSave").setAttribute("value", "Edit");
                    document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                })
        }
    }


    // Buscar
    $scope.BuscarPessoa = function () {
        $http({
            method: "get",
            url: "/Pessoa/BuscarPessoa"
        }).then(function (response) {
            $scope.pessoas = response.data;
        }, function (response) {
            alert("Error");
        })
    };


    //Deletar
    $scope.DeletePessoa = function (Obj) {
        $http({
            method: "post",
            url: "/Pessoa/DeletePessoa",
            datatype: "json",
            data: JSON.stringify(Obj)
        }).then(function (response) {
            if (response.data == "Sucesso") {
                $('#MensagemErro').hide();
                $('#MensagemSucesso').hide();
                $('#MesagemEditar').hide();
                $('#MensagemDeletar').show();
            } else {
                $('#MensagemSucesso').hide();
                $('#MesagemEditar').hide();
                $('#MensagemDeletar').hide();
                $('#MensagemErro').show();
            }
            $scope.BuscarPessoa();
        })
    };





    //Editar
    $scope.EditarPessoa = function (Obj) {
        $('#myModal').modal('show');
        $scope.F_IdPessoa = Obj.IdPessoa;
        $scope.F_Nome = Obj.Nome;
        $scope.F_Email = Obj.Email;
        $scope.F_Telefone = Obj.Telefone;
        $scope.F_Idade = Obj.Idade;
        $scope.F_Skype = Obj.Skype;
        $scope.F_Cidade = Obj.Cidade;
        $scope.F_Portfolio = Obj.Portfolio;
        $scope.F_Estado = Obj.Estado;
        $scope.F_NomePessoaBanco = Obj.NomePessoaBanco;
        $scope.F_CPF = Obj.CPF;
        $scope.F_NomeBanco = Obj.NomeBanco;
        $scope.tipocontasselecionado = Obj.TipoConta;
        $scope.F_Agencia = Obj.Agencia;
        $scope.F_NrConta = Obj.NrConta;
        $scope.F_OPConta = Obj.OPConta;
        $scope.disponibilidadesselecionado = Obj.Disponibilidade;
        $scope.horariosselecionado = Obj.Horario;
        $scope.experiencias = Obj.Experiencia;
        $("#btnSave").attr("type", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Blue";
    }



    //Adicionar Experiencia
    $scope.AdicionarExperiencia = function () {
        var Obj = {
            Nome: $scope.F_Linguagem,
            Nivel: $scope.nivelselecionado,
        }
        $scope.experiencias.push(Obj);
        $scope.nivelselecionado = null;
        $scope.F_Linguagem = "";
    }

    //Remover Experiencia
    $scope.RemoverExperiencia = function (Obj) {
        $scope.experiencias.splice(Obj, 1);
    }

})