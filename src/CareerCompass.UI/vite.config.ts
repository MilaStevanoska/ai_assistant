import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import fs from "fs";
import path from "path";
import tailwindcss from "@tailwindcss/vite";
import mkcert from 'vite-plugin-mkcert'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react(), tailwindcss(), mkcert()],
  server: {
    https: {
      key: fs.readFileSync(path.resolve(__dirname, "certs", "key.pem")),
      cert: fs.readFileSync(path.resolve(__dirname, "certs", "cert.pem")),
    },
  },
});
