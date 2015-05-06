var Player = function (socket, name, room) {
    this.Name = name;
    this.Socket = socket;
    this.Room = room;
};

var PlayersArray = [];

var express = require('express');

var app = express();

var http = require('http').Server(app);

var io = require('socket.io')(http);

var countOfRooms = 0;

app.get('/', function (req, res) {
    res.sendFile(__dirname + '/index.html');
});

app.get(/^(.+)$/, function (req, res) {
    console.log('static file request : ' + req.params[0]);
    res.sendfile(__dirname + req.params[0]);
});

http.listen(3000, function () {
    console.log('listening on *:3000');
});

io.on('connection', function (socket) {

    console.log('a user connected');
});

io.on('connection', function (socket) {
    socket.on('chat message', function (msg) {
        console.log('message: ' + msg);
    });

    socket.on("setNickname", function (nickname) {
        socket.join("waitRoom");
        PlayersArray[PlayersArray.length] = new Player(socket, nickname, "waitRoom");
        if(CheckForAwailableGame()==false){
            socket.emit("wait");
        }
    });

    socket.on("move", function(oldX, oldY, newX, newY, color,queen){
        Move(socket,oldX,oldY,newX,newY,color, queen);
    });

    socket.on("eat", function(x, y){
        Eat(socket,x,y);
    });

    socket.on("setEnemyQueen", function(x, y){
        SetEnemyQueen(socket,x,y);
    });

    socket.on("endMove", function(){
        EndMove(socket);
    });

    socket.on('disconnect', function () {
       OpponentDisconnect(socket);
    });
});

function OpponentDisconnect(socket){
    var foundedPlayer;
    for (var i=0; i<PlayersArray.length; i++){
        if(PlayersArray[i].Socket===socket){
            foundedPlayer=PlayersArray[i];
            break;
        }
    }
    if(foundedPlayer!=undefined) {
        var room = io.nsps["/"].adapter.rooms[foundedPlayer.Room];
        for (var socketId in room) {
            var currentSocket = io.sockets.connected[socketId];
            if (currentSocket != socket) {
                currentSocket.emit("opponentDisconnect");
                currentSocket.leave(foundedPlayer.Room);
                currentSocket.join("waitRoom");
                foundedPlayer.Room = "waitRoom";
                CheckForAwailableGame();
            }
        }
    }
}

function SetEnemyQueen(socket, x,y){
    var foundedPlayer;
    for (var i=0; i<PlayersArray.length; i++){
        if(PlayersArray[i].Socket===socket){
            foundedPlayer=PlayersArray[i];
            break;
        }
    }
    var room = io.nsps["/"].adapter.rooms[foundedPlayer.Room];
    for(var socketId in room){
        var currentSocket=io.sockets.connected[socketId];
        if(currentSocket!=socket){
            currentSocket.emit("setEnemyQueen", x, y);
        }
    }
}

function Eat(socket, x,y){
    var foundedPlayer;
    for (var i=0; i<PlayersArray.length; i++){
        if(PlayersArray[i].Socket===socket){
            foundedPlayer=PlayersArray[i];
            break;
        }
    }
    var room = io.nsps["/"].adapter.rooms[foundedPlayer.Room];
    for(var socketId in room){
        var currentSocket=io.sockets.connected[socketId];
        if(currentSocket!=socket){
            currentSocket.emit("eat", x, y);
        }
    }
}

function Move(socket,oldX, oldY, newX, newY, color, queen){
    var foundedPlayer;
    for (var i=0; i<PlayersArray.length; i++){
        if(PlayersArray[i].Socket===socket){
            foundedPlayer=PlayersArray[i];
            break;
        }
    }
    var room = io.nsps["/"].adapter.rooms[foundedPlayer.Room];
    for(var socketId in room){
        var currentSocket=io.sockets.connected[socketId];
        if(currentSocket!=socket){
            currentSocket.emit("move", oldX, oldY,newX,newY,color, queen);
        }
    }
}

function EndMove(socket){
    var foundedPlayer;
    for (var i=0; i<PlayersArray.length; i++){
        if(PlayersArray[i].Socket===socket){
            foundedPlayer=PlayersArray[i];
            break;
        }
    }
    var room = io.nsps["/"].adapter.rooms[foundedPlayer.Room];
    for(var socketId in room){
        var currentSocket=io.sockets.connected[socketId];
        if(currentSocket!=socket){
            currentSocket.emit("endMove");
        }
    }
}

function CheckForAwailableGame() {
    var room = io.nsps["/"].adapter.rooms["waitRoom"];
    var countInWaitRoom = Object.keys(room).length;
    if (countInWaitRoom >= 2) {
        var counter = 0;
        var firstClient;
        var secondClient;
        for (var socketId in io.nsps["/"].adapter.rooms["waitRoom"]) { // Да простит аллах за это уродство
            if (counter == 0) {
                firstClient = io.sockets.connected[socketId];
            }
            else {
                secondClient = io.sockets.connected[socketId];
            }
            counter++;
            if (counter >= 2) {
                break;
            }
        }

        firstClient.leave("waitRoom");
        secondClient.leave("waitRoom");
        firstClient.join(countOfRooms);
        secondClient.join(countOfRooms);
        var firstName;
        var secondName;
        for (var i = 0; i < PlayersArray.length; i++) {
            if(PlayersArray[i].Socket===firstClient){
                firstName=PlayersArray[i].Name;
                PlayersArray[i].Room = countOfRooms;
            }
            if(PlayersArray[i].Socket===secondClient){
                secondName=PlayersArray[i].Name;
                PlayersArray[i].Room = countOfRooms;
            }
        }
        countOfRooms++;

        firstClient.emit("gameReady", true, secondName);
        secondClient.emit("gameReady", false, firstName);
        return true;
    }
    return false;
}
