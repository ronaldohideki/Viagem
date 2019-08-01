function Enviar()
{
    var _title = document.title;
    var _ip = document.getElementById('ip').value;
    var _navegador = bowser.getParser(window.navigator.userAgent);
    var _browser = _navegador.parsedResult.browser.name;

    var dadosPagina = {
        NomePagina: _title,
        Ip: _ip,
        Navegador: _browser
    }

    var xhr = new XMLHttpRequest();   
    xhr.open('POST', 'http://localhost:62407/api/values', true);
    
    xhr.setRequestHeader("Content-Type", "application/json");    
    xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
    xhr.withCredentials = false;

    xhr.onload = function () {
        // console.log(this.responseText);
        obj = JSON.parse(this.responseText);

        console.log(obj);
        console.log(dadosPagina);
    }

    xhr.send(dadosPagina);
}	

