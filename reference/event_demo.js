const EventEmitter = require('events');

class MYEmitter extends EventEmitter{}

//Init object
const myEmitter= new MYEmitter();

//Event listener
myEmitter.on('event', ()=> console.log('Event Fired!'));

//Init event
myEmitter.emit('event');