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
          name: "admin",
          filename: "remoteEntry.js",
          exposes: {
            "./AdminPanel": "./src/App"
          },
          remotes: {},
          shared: {
            ...deps,
            ui: {
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
            }
          }
        })
      ]
    }
  }
})};