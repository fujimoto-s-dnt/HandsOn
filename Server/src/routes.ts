// File: routes.ts
// Author: 藤本シゲオ（fujimoto.shigeo@donuts.ne.jp）
// Description: サーバーのAPIルートの定義

// ルーターを依存まとめファイルから引っ張る
import { Router, base64 } from "./deps.ts";

import masterData from "../database.json" with {type: "json"};

// 初期化する
const router = new Router();

// データ初期化用のエンドポイント
router.get("/master/getDefaultData", (context) => {
    context.response.body = masterData.playerDataDefault;
});

// キャラマスタ取得用のエンドポイント
router.get("/master/getCharacterMaster", (context) => {
    context.response.body = masterData.characterMaster;
});

// ステージマスタ取得用のエンドポイント
router.get("/master/getStageMaster", (context) => {
    context.response.body = masterData.stageMaster;
});

// ガチャマスタ取得用のエンドポイント
// たーぶんつかわん
router.get("/master/getGachaMaster", (context) => {
    context.response.body = masterData.gachaMaster;
});

interface GachaMaster {
    id: number;
    weight: number;
}

// ガチャを引くためのエンドポイント
router.get("/gacha/draw", (context) => {

    const master: GachaMaster[] = masterData.gachaMaster;

    const gachaArray = new Array<number>();

    master.forEach((value) => {
        const tempArray = new Array<number>(value.weight).fill(value.id);
        gachaArray.push(...tempArray);
    });

    const result = gachaArray[Math.floor(Math.random() * gachaArray.length)];

    context.response.body = result;
});

// exportして、他のファイルで使えるようにする
// export defaultにすることで、中括弧なしでimportできる
// なお、なぜそうなるかについてはTSの仕様読みましょう。（ワイにはわからん）
export default router;