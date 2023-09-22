function pesquisacep(valor) {

    var cep = valor.replace(/\D/g, '');

    if (cep != "") {

        var validacep = /^[0-9]{8}$/;

        if (validacep.test(cep)) {

            document.getElementById('Logradouro').value = "...";

            var script = document.createElement('script');

            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=preencherDadosEndereco';

            document.body.appendChild(script);

        }
        else {
            LimpaCamposEndereço();
            alert("Formato de CEP inválido.");
        }
    } 
    else {
        LimpaCamposEndereço();
    }
}

function preencherDadosEndereco(conteudo) {
    if (!("erro" in conteudo)) {
        document.getElementById('Logradouro').value = (conteudo.logradouro);
        document.getElementById('Bairro').value = (conteudo.bairro);
        document.getElementById('Cidade').value = (conteudo.localidade);

        var selectEstado = document.querySelector('#Estado');
        for (var i = 0; i < selectEstado.options.length; i++) {
            if (selectEstado.options[i].text === conteudo.uf.toUpperCase()) {
                selectEstado.selectedIndex = i;
                break;
            }
        }
    }
    else {
        LimpaCamposEndereço();
        alert("CEP não encontrado")
    }
}

function limparCamposEndereco() {
    document.getElementById('Logradouro').value = "...";
    document.getElementById('Numero').value = "...";
    document.getElementById('Complemento').value = "...";
    document.getElementById('Bairro').value = "...";
    document.getElementById('Cidade').value = "...";
    document.getElementById('Estado').value = "...";
}