const { ModuleFederationPlugin } = require("webpack").container;

const deps = require("./package.json").dependencies;

module.exports = () => ({
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
            identity: "identity@http://localhost:3001/remoteEntry.js"
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
});