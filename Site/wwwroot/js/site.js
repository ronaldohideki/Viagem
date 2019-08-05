function Enviar()
{
    var _title = document.title;
    var _ip =  document.getElementById('ip').value;
    var _navegador = bowser.getParser(window.navigator.userAgent);
    var _browser = _navegador.parsedResult.browser.name;

    var _dadosPagina = {
        ip: _ip,
        nomePagina: _title,
        navegador: _browser
    };

    var xhr = new XMLHttpRequest();  
    xhr.open('POST','http://localhost:62407/api/values', true);   
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    xhr.onload = function () {
        console.log(this.responseText);
        var   obj = JSON.parse(this.responseText);
        console.log(obj);

        if (xhr.readyState === 4 && xhr.status === 200)
        { 
            console.log("deu certo")
         
        }
        else
        {
            console.log("deu errado")
        }
    }
    xhr.send(JSON.stringify(_dadosPagina, null, '  '));
}