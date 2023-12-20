// File: mixRoutes.ts
// Author: 藤本シゲオ（fujimoto.shigeo@donuts.ne.jp）
// Description: サーバー実行ファイル（いわゆる、main）

// 色々インポート
import { Application } from "./deps.ts";
import router from "./routes.ts";

// Denoでもenv使えますぜ！
//（使ってないが。）
const env = Deno.env.toObject();
const PORT = env.PORT || 5555;
const HOST = env.HOST || '0.0.0.0';

// Oakの初期化
const app = new Application();
// サンプルルーター追加
app.use(router.routes());
app.use(router.allowedMethods());

console.log(`Server running on port ${PORT}`);

// サーバー起動
app.listen(`${HOST}:${PORT}`);