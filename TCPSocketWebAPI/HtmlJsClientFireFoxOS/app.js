/* 
    Copyright (C) 2014 LookugA

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
var socket;
window.addEventListener("load", function() {
  
  document.getElementById("btnclick").addEventListener("click", function(){
    doit();
});
  
  Log("Click the above button to make a request to the Server.<br><br>Log:<br>");
  socket = navigator.mozTCPSocket.open('localhost', 8080);
  socket.ondata = function (event) {
    if (typeof event.data === 'string') {
      Log('Response: ' + event.data);
    }
  }
  socket.onerror = function (event) {
    Log(event.data.name);
  }
  socket.onopen = function (event) {
    Log("Connection Opened")
    console.log(event);
  }
});

function Log(text)
{
  document.getElementById("log").innerHTML = 
    document.getElementById("log").innerHTML + "<br>" + text;
}

function doit()
{
  Log("Sending... " + 'hello world')
  socket.send('hello world');
}