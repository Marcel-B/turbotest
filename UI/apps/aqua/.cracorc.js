const { ModuleFederationPlugin } = require("webpack").container;

const deps = require("./package.json").dependencies;

module.exports = ({...args}) => {
  console.log("__Args", args);
  return ({
  webpack: {
    configure: {
      output: {
        publicPath: "auto"
      }
    },
    plugins: {
      add: [
        new ModuleFederationPlugin({
          name: "aqua",
          filename: "remoteEntry.js",
          exposes: {
            "./InfoCard": "./src/InfoContent"
          },
          remotes: {
            identity: args.env === 'development' ?  "identity@http://localhost:3001/remoteEntry.js" : "identity@http://192.168.2.103:6060/remoteEntry.js",
            admin: args.env === 'development' ? "admin@http://localhost:3066/remoteEntry.js" : "admin@http://192.168.2.103:9066/remoteEntry.js"
          },
          shared: {
            ...deps,
            "add-menu": {
              singleton: true
            },
            feed: {
              singleton: true
            },
            info: {
              singleton: true
            },
            oidc: {
              singleton: true
            },
            ui: {
              singleton: true
            },
            timer: {
              singleton: true
            },
            righthand: {
              singleton: true
            },
            "shared-types": {
              singleton: true
            },
            store: {
              singleton: true
            },
            tsconfig: {
              singleton: true
            },
            react: {
              singleton: true,
              requiredVersion: deps.react
            },
            "react-dom": {
              singleton: true,
              requiredVersion: deps["react-dom"]
            },
            "user-menu": {
              singleton: true
            },
            "user-profile": {
              singleton: true
            }
          }
        })
      ]
    }
  }
})};