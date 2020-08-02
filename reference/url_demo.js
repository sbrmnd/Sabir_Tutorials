const url = require('url');

const myurl = new url.URL('http://mywebsite.com/hello.html?id=100&status=active');

//Serialized URL

console.log(myurl.href); // console.log(myurl.toString());

//Host(root domain)
console.log(myurl.host);

//hostname(does not get port)
console.log(myurl.hostname);

//pathname
console.log(myurl.pathname);

//Serialized query
console.log(myurl.search);

//Params objects
console.log(myurl.searchParams);

//Add param
myurl.searchParams.append('abc','123');
console.log(myurl.searchParams);

//Loop through params
myurl.searchParams.forEach((value,name)=>console.log(`${value}:${name}`));
