/**
 * webpack config for module export
 * to install go to main directory (wwwroot)
 * and make> `npm run build`
 */

const path = require('path');
const webpack = require('webpack');
const ChunksWebpackPlugin = require('chunks-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const ExtractCssChunks = require('extract-css-chunks-webpack-plugin');

module.exports = {
    mode: 'production',
    resolve: {
        /**
        * Importent !!!
        */
        alias: {
            jquery: '@progress/kendo-ui/node_modules/jquery/dist/jquery'
        }
    },
    entry: {
        default: './src/default.all.min.js',
    },
    output: {
        filename: '[contenthash].bundle.js',
        chunkFilename: '[contenthash].bundle.js',
        path: path.resolve(__dirname, 'dist'),
    },
    optimization: {
        minimize: true,
        splitChunks: {
            chunks: 'all',
            minSize: 32768,
            maxSize: 131072,
            minChunks: 1,
            maxAsyncRequests: 6,
            maxInitialRequests: 4,
            automaticNameDelimiter: '~',
            name: false,
            cacheGroups: {
                defaultVendors: {
                    test: /[\\/]node_modules[\\/]/,
                    priority: -10
                },
                default: {
                    minChunks: 2,
                    priority: -20,
                    reuseExistingChunk: true
                },
            }
        },
    },
    module: {
        rules: [
            {
                test: /\.less$/,
                use: ['style-loader', 'css-loader', 'less-loader']
            },
            {
                test: /\.css$/,
                use: [
                    {
                        loader: 'file-loader',
                    },
                    {
                        loader: MiniCssExtractPlugin.loader,
                    },
                    {
                        loader: 'css-loader',
                    },
                ],
            },
            {
                test: /.(png|jpe?g|gif|svg|woff|woff2|otf|ttf|eot|ico)$/,
                use: [
                    {
                        loader: 'file-loader',
                    }
                ]
            },
            {
                test: /\.json$/,
                loader: 'json-loader'
            },
        ]
    },
    plugins: [
        new ExtractCssChunks({
            filename: '[contenthash].css',
            chunkFilename: '[contenthash].css',
        }),
        new MiniCssExtractPlugin({
            filename: '[contenthash].css',
            chunkFilename: '[contenthash].css',
        }),
        new ChunksWebpackPlugin({
            generateChunksManifest: true,
            templateStyle: `<link rel='stylesheet' href='/vendor{{chunk}}' />`,
            templateScript: `<script type='text/javascript' src='/vendor{{chunk}}'></script>`,
        }),
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
        }),
    ],
}