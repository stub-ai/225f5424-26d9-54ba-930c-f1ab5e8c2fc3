const http = require('http');
const fs = require('fs');

const server = http.createServer((req, res) => {
  fs.readFile('./yourfile.txt', (err, data) => {
    if (err) {
      res.statusCode = 500;
      res.end(`Error getting the file: ${err}.`);
    } else {
      res.statusCode = 200;
      res.setHeader('Content-type', 'text/plain');
      res.end(data);
    }
  });
});

server.listen(7022, () => {
  console.log('Server listening on http://localhost:7022/yourfile.txt');
});