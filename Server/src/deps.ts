// File: deps.ts
// Author: 藤本シゲオ（fujimoto.shigeo@donuts.ne.jp）
// Description: 依存ライブラリ等のまとめファイル

// DenoはNodeと違って、ランタイムで依存解決するので、依存周りは1ファイルにまとめている
import { Application, Router } from "https://deno.land/x/oak@v12.1.0/mod.ts";
import { base64 } from "https://deno.land/x/oak@v12.1.0/deps.ts";

// exportして、他のファイルで使えるようにする
export { Router, Application, base64 };
