"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const realm_object_server_1 = require("realm-object-server");
const path = require("path");
const server = new realm_object_server_1.BasicServer();
server.start({
    dataPath: path.join(__dirname, "../data"),
    logger: new realm_object_server_1.FileConsoleLogger(path.join(__dirname, "../log.txt"), "all", {
        file: {
            timestamp: true,
            level: "debug"
        },
        console: {
            level: "info"
        }
    }),
    featureToken: "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJOb3RpZmllciI6dHJ1ZSwiU3luYyI6dHJ1ZSwiTG9hZEJhbGFuY2luZyI6dHJ1ZSwiQWRhcHRlciI6dHJ1ZSwiQmFja3VwIjp0cnVlLCJDbGllbnRFbWFpbCI6Imp1YW5tYW51ZWwuZ2VudGlsaUBmb2xsb3dvei5jb20iLCJpYXQiOjE1NTk4MzQyMjMsImV4cCI6MTU2MjQyNjIyM30.BHwR1GA8POKbdiZg8X7HApaxMyakJ0JODI17CAMMO2wbr6l4xMitPemhDLHTY6FDuh95wwCl69FrA3wmx4YHESkHN7pZXADyH04yCvqxT3x4ITwzNqNoBlJuC1kQRmoibdU6tU4x66vARUuvly6hJy70Yoo0wtUmaQfNxzeLelcIu4yCmG9jfWKBnKLoxoqKN5guZBGB-v53HzR9GdEfaY5nkQ7vbqO6By5m3fM9VcDslowxcXykzNmdExJnd_t6EAnx95hlWSN1UZNOAol5DMwQPV6kCrGMA2rgwwCzQ9zQUrVuDorGie3orjcYWM2hH3Jgu1qh9rUqCtnvf7sd-g",
})
    .then(() => {
    console.log(`Realm Object Server was started on ${server.address}`);
})
    .catch(err => {
    console.error(`Error starting Realm Object Server: ${err.message}`);
});
//# sourceMappingURL=index.js.map