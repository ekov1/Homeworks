function extract(args) {

    var string = args[0],
        protoEnd = string.indexOf(':'),
        protocol = string.substring(0, protoEnd),
        serverStart = string.indexOf('://'),
        serverEnd = string.indexOf('/', serverStart + 3),
        server = "",
        resource = "";

    server = string.substring(serverStart + 3, serverEnd);

    resource = string.substring(serverEnd, string.length);

    console.log('protocol: ' + protocol);
    console.log('server: ' + server);
    console.log('resource: ' + resource);
}
