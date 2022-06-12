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
          name: "identity",
          filename: "remoteEntry.js",
          exposes: {
            "./LoginUser": "./src/App"
          },
          shared: {
            ...deps,
            "shared-types": {
              singleton: true
            },
            store: {
              singleton: true
            },
            tsconfig: {
              singleton: true
            },
            "login-form": {
              singleton: true
            },
            react: {
              singleton: true,
              requiredVersion: deps.react
            },
            "react-dom": {
              singleton: true,
              requiredVersion: deps["react-dom"]
            }
          }
        })
      ]
    }
  }
});