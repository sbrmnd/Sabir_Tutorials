const path = require('path');

//Base file name 
console.log(path.basename(__filename));

//Directory name
console.log(path.dirname(__filename));

//file extension
console.log(path.extname(__filename));

//Create path object
//console.log(path.parse(__filename));

//Since above is object we can get the properties
console.log(path.parse(__filename).base);

//Concatenate paths
console.log(path.join(__dirname,'test','hello.html'));