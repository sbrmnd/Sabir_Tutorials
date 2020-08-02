const fs = require('fs');
const path= require('path');

//Create folder
//fs.mkdir(path.join(__dirname,'//test'),{}, function(err){
//    if(err) throw err;
//    console.log('folder Created..');
//}));

//Lamda expression for function
/*fs.mkdir(path.join(__dirname, '/test'), {}, err => {
    if (err) throw err;
    console.log('folder created..');
});*/

//Create and write to file
/*fs.writeFile(path.join(__dirname,'/test','hello.txt'),
'Content of the file written to!',
err=>{
    if(err) throw err;
    console.log('File written to...');

 //File Append
    fs.appendFile(path.join(__dirname, '/test', 'hello.txt'),
        'Content appended..',
        err => {
            if (err) throw err;
            console.log('File written to...');
    
}
);*/

//Read file 
// fs.readFile(path.join(__dirname, '/test','hello.txt'), 'utf8', (err,data) => {
//     if (err) throw err;
//     console.log(data);
// });

fs.rename(path.join(__dirname, '/test','hello.txt'), path.join(__dirname, '/test','helloWorld.txt'), err => {
    if (err) throw err;
    console.log('File renamed..');
});