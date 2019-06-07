import { BasicServer, FileConsoleLogger } from "realm-object-server";
import * as path from "path";

const server = new BasicServer();

server.start({
        // For all the full list of configuration parameters see:
        // https://realm.io/docs/realm-object-server/latest/api/ros/interfaces/serverconfig.html

        // This is the location where ROS will store its runtime data
        dataPath: path.join(__dirname, "../data"),

        // A logger to pipe ROS information. You can also specify the log level.
        // The log level can be one of: all, trace, debug, detail, info, warn, error, fatal, off.
        logger: new FileConsoleLogger(path.join(__dirname, "../log.txt"), "all", {
            file: {
                timestamp: true,
                level: "debug"
            },
            console: {
                level: "info"
            }
        }),

        // The feature token acquired from Realm. This must be set to a valid token
        // string to start the server. Please note that "Developer Edition" was
        // phased out in March 2018. Free-tier users are encouraged to move to Realm
        // Cloud (see https://cloud.realm.io for more information).
        featureToken: "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJOb3RpZmllciI6dHJ1ZSwiU3luYyI6dHJ1ZSwiTG9hZEJhbGFuY2luZyI6dHJ1ZSwiQWRhcHRlciI6dHJ1ZSwiQmFja3VwIjp0cnVlLCJDbGllbnRFbWFpbCI6Imp1YW5tYW51ZWwuZ2VudGlsaUBmb2xsb3dvei5jb20iLCJpYXQiOjE1NTk4MzQyMjMsImV4cCI6MTU2MjQyNjIyM30.BHwR1GA8POKbdiZg8X7HApaxMyakJ0JODI17CAMMO2wbr6l4xMitPemhDLHTY6FDuh95wwCl69FrA3wmx4YHESkHN7pZXADyH04yCvqxT3x4ITwzNqNoBlJuC1kQRmoibdU6tU4x66vARUuvly6hJy70Yoo0wtUmaQfNxzeLelcIu4yCmG9jfWKBnKLoxoqKN5guZBGB-v53HzR9GdEfaY5nkQ7vbqO6By5m3fM9VcDslowxcXykzNmdExJnd_t6EAnx95hlWSN1UZNOAol5DMwQPV6kCrGMA2rgwwCzQ9zQUrVuDorGie3orjcYWM2hH3Jgu1qh9rUqCtnvf7sd-g",

        // The address on which to listen for connections
        // address?: string = '0.0.0.0'
        // address: '0.0.0.0',

        // The port on which to listen for connections
        // port?: number = 9080
        // port: 9080,

        // Override the default list of authentication providers
        // the default has PasswordAuthProvider, AnonymousAuthProvider, and NicknameAuthProvider
        // you will need to add `import { auth, BasicServer } from 'realm-object-server'
        // authProviders?: IAuthProvider[]
        // authProviders: [new auth.PasswordAuthProvider({ autoCreateAdminUser: true }), new auth.NicknameAuthProvider(), new auth.AnonymousAuthProvider()]

        // Autogenerate public and private keys on startup
        // autoKeyGen?: boolean = true
        // autoKeyGen: true,

        // Specify an alternative path to the private key. Otherwise, it is expected to be under the data path.
        // privateKeyPath?: string
        // privateKeyPath: '',

        // Specify an alternative path to the public key. Otherwise, it is expected to be under the data path.
        // publicKeyPath?: string
        // publicKeyPath: '',

        // The desired logging threshold. Can be one of: all, trace, debug, detail, info, warn, error, fatal, off)
        // logLevel?: string = 'info'
        // logLevel: 'info',

        // Enable the HTTPS Server.
        // https?: boolean = false
        // https: true,

        // The port on which to listen for HTTPS connections.
        // httpsAddress?: string = '0.0.0.0',
        // httpsAddress: '0.0.0.0',

        // The address on which to listen for HTTPS connections.
        // httpsPort?: number = 9443
        // httpsPort: 9443,

        // The path to your HTTPS private key in PEM format. Required if HTTPS is enabled.
        // httpsKeyPath?: string
        // httpsKeyPath: '',

        // The path to your HTTPS certificate chain in PEM format. Required if HTTPS is enabled.
        // httpsCertChainPath?: string
        // httpsCertChainPath: '',

        // Specify the length of time (in seconds) in which access tokens are valid.
        // accessTokenTtl?: number = 600 (ten minutes)
        // accessTokenTtl: 600,

        // Specify the length of time (in seconds) in which refresh tokens are valid.
        // refreshTokenTtl?: number = 3153600000 (ten years)
        // refreshTokenTtl: 3153600000,

        // Enable Log Compaction to save on bandwidth
        // read more at https://docs.realm.io/platform/self-hosting/customize/log-compaction
        // enableLogCompaction?: boolean = true
        // enableLogCompaction: true

        // Increase or decrease the max download size.
        // This affects how the Log Compaction works
        // read more at https://docs.realm.io/platform/self-hosting/customize/log-compaction
        // maxDownloadSize?: number 16000000 (16 megabytes)
        // maxDownloadSize: 16000000

        // Clients that haven't been seen by the server for longer than the historyTtl will
        // be ignored by the server when it calculates the maximum version up to which it
        // can compact the history. If an older client connects, it may experience a client
        // reset due to the server having compacted history that they rely on for operational
        // transformation. The default value is infinite.
        // Read more about client resets at
        // https://docs.realm.io/platform/using-synced-realms/troubleshoot/errors#client-reset.
        // historyTtl?: number
        // historyTtl: 3600 * 24 * 30 // 30 days
    })
    .then(() => {
        console.log(`Realm Object Server was started on ${server.address}`);
    })
    .catch(err => {
        console.error(`Error starting Realm Object Server: ${err.message}`);
    });
