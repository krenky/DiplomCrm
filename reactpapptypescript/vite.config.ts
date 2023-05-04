import { defineConfig } from 'vite';
import path from 'path';
import fs from 'fs';
import react from '@vitejs/plugin-react';

const packages = fs.readdirSync(path.resolve(__dirname, './node_modules'));
const aliases = packages.reduce((acc, dirName) => {
    const packageJson = require(path.resolve(
        __dirname,
        './',
        'package.json'
    ));
    acc[packageJson.name] = path.resolve(
        __dirname,
        `${path.resolve('../..')}/packages/${packageJson.name}/src`
    );
    return acc;
}, {});

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [react()],
    define: {
        "process.env": `(${JSON.stringify(process.env)})`
    },
    server: {
        port: 8000,
        open: true,
    },
    base: './',
    esbuild: {
        keepNames: true,
    },
    build: {
        sourcemap: true,
        lib:{
            entry: path.resolve('./src', 'index.tsx'),
            name: 'MyLib',
            fileName: (format) => `my-lib.${format}.js`
        }
    },
    resolve: {
        preserveSymlinks: true,
        alias: [
            // allow profiling in production
            { find: 'react-dom', replacement: 'react-dom/profiling' },
            {
                find: 'scheduler/tracing',
                replacement: 'scheduler/tracing-profiling',
            },
            // we need to manually follow the symlinks for local packages to allow deep HMR
            ...Object.keys(aliases).map(packageName => ({
                find: packageName,
                replacement: aliases[packageName],
            })),
        ],
    },
});
