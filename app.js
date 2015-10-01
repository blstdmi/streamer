var exp = require('express');
var fileSystem = require('fs');
var serverNode = exp.createServer(exp.logger());

serverNode.get('/', function(request, response) 
{
	response.send('<img src=stream.mjpeg>');
});

serverNode.get('/stream.mjpeg', function(request, res) 
{
	res.writeHead(200,
	{
		'Content-Type': 'multipart/x-mixed-replace; boundary=myboundary',
		'Cache-Control': 'no-cache',
		'Connection': 'close',
		'Pragma': 'no-cache'
	});

	var i = 0;
	var stop = false;
	res.connection.on('close', function() { stop = true; });
	var nextFrame = function() 
	{
		if (stop)
		{
			return;
		}
		i = (i+1) % 3;
		var filename = i + ".jpg";
		fileSystem.readFile(__dirname + '/resources/' + filename, function (err, content) 
		{
			res.write("--myboundary\r\n");
			res.write("Content-Type: image/jpeg\r\n");
			res.write("Content-Length: " + content.length + "\r\n");
			res.write("\r\n");
			res.write(content, 'binary');
			res.write("\r\n");
			setTimeout(nextFrame, 500);
		});
	};
	nextFrame();
});


var port = process.env.PORT || 5000;
serverNode.listen(port, function() 
{
	console.log("localhost:" + port);
});
