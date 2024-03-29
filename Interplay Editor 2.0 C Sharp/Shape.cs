﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interplay_Editor_2_C_Sharp.Classes;


namespace Interplay_Editor_2_C_Sharp
{
 
    /*  Shape Class
     *  
     * 
     * 
     */
    public class Shape
    {
        public const int SHAPES_NUM = 700;                                          // Number of Shapes
        public int w;                                                               // Width of sprites
        public int h;                                                               // Height of sprites.
        public byte[] shapePixmap;                                                  // Byte array for ALL data in the Shape.DAT file.
        public Pixmap[] pixmaps;                                                    // Data broken down into pixmaps.  4 per shape.
        public int pixmaps_num;                                                     // Number of individual pixmaps.
        static readonly int [,] shapes_param = new int[SHAPES_NUM,2]                // (Height value, number of sprites.
        {
            {24, 4},                    /* index=0   hobbit */
            {24, 4},                    /* index=1 */
            {24, 4},                    /* index=2 */
            {24, 4},                    /* index=3 */
            {24, 4},                    /* index=4 */
            {24, 4},                    /* index=5 */
            {32, 4},                    /* index=6   wolf */
            {32, 4},                    /* index=7 */
            {32, 4},                    /* index=8 */
            {32, 4},                    /* index=9 */
            {32, 4},                    /* index=10 */
            {32, 4},                    /* index=11 */
            {24, 4},                    /* index=12  spider */
            {24, 4},                    /* index=13 */
            {24, 4},                    /* index=14 */
            {24, 4},                    /* index=15 */
            {24, 4},                    /* index=16 */
            {24, 4},                    /* index=17 */
            {32, 4},                    /* index=18  elf */
            {32, 4},                    /* index=19 */
            {32, 4},                    /* index=20 */
            {32, 4},                    /* index=21 */
            {32, 4},                    /* index=22 */
            {32, 4},                    /* index=23 */
            {25, 4},                    /* index=24  man in green */
            {25, 4},                    /* index=25 */
            {25, 4},                    /* index=26 */
            {25, 4},                    /* index=27 */
            {25, 4},                    /* index=28 */
            {25, 4},                    /* index=29 */
            {25, 4},                    /* index=30  dwarf */
            {25, 4},                    /* index=31 */
            {25, 4},                    /* index=32 */
            {25, 4},                    /* index=33 */
            {25, 4},                    /* index=34 */
            {25, 4},                    /* index=35 */
            {0, 0},                     /* index=36 */
            {0, 0},                     /* index=37 */
            {0, 0},                     /* index=38 */
            {0, 0},                     /* index=39 */
            {0, 0},                     /* index=40 */
            {0, 0},                     /* index=41 */
            {0, 0},                     /* index=42 */
            {0, 0},                     /* index=43 */
            {0, 0},                     /* index=44 */
            {0, 0},                     /* index=45 */
            {0, 0},                     /* index=46 */
            {0, 0},                     /* index=47 */
            {32, 4},                    /* index=48  upper left Balrog part */
            {32, 4},                    /* index=49 */
            {32, 4},                    /* index=50 */
            {32, 4},                    /* index=51 */
            {32, 2},                    /* index=52 */
            {32, 4},                    /* index=53 */
            {32, 4},                    /* index=54  lower right Balrog part */
            {32, 4},                    /* index=55 */
            {32, 4},                    /* index=56 */
            {32, 4},                    /* index=57 */
            {32, 2},                    /* index=58 */
            {32, 4},                    /* index=59 */
            {0, 0},                     /* index=60 */
            {0, 0},                     /* index=61 */
            {0, 0},                     /* index=62 */
            {0, 0},                     /* index=63 */
            {0, 0},                     /* index=64 */
            {90, 1},                    /* index=65  swanship */
            {35, 4},                    /* index=66  ponny */
            {35, 4},                    /* index=67 */
            {35, 4},                    /* index=68 */
            {35, 4},                    /* index=69 */
            {0, 0},                     /* index=70 */
            {35, 4},                    /* index=71  Bombadil, Radagast */
            {30, 4},                    /* index=72 */
            {30, 4},                    /* index=73 */
            {30, 4},                    /* index=74 */
            {30, 4},                    /* index=75 */
            {30, 4},                    /* index=76 */
            {30, 4},                    /* index=77 */
            {32, 4},                    /* index=78  Gandalf */
            {32, 4},                    /* index=79 */
            {32, 4},                    /* index=80 */
            {32, 4},                    /* index=81 */
            {32, 4},                    /* index=82 */
            {32, 4},                    /* index=83 */
            {0, 0},                     /* index=84 */
            {0, 0},                     /* index=85 */
            {0, 0},                     /* index=86 */
            {0, 0},                     /* index=87 */
            {0, 0},                     /* index=88 */
            {0, 0},                     /* index=89 */
            {24, 4},                    /* index=90  woman hobbit */
            {24, 4},                    /* index=91 */
            {24, 4},                    /* index=92 */
            {24, 4},                    /* index=93 */
            {0, 0},                     /* index=94 */
            {24, 4},                    /* index=95 */
            {24, 4},                    /* index=96  Freddi */
            {24, 4},                    /* index=97 */
            {24, 4},                    /* index=98 */
            {24, 4},                    /* index=99 */
            {24, 4},                    /* index=100 */
            {24, 4},                    /* index=101 */
            {24, 4},                    /* index=102 Gaffer */
            {24, 4},                    /* index=103 */
            {24, 4},                    /* index=104 */
            {24, 4},                    /* index=105 */
            {24, 4},                    /* index=106 */
            {24, 4},                    /* index=107 */
            {0, 0},                     /* index=108 */
            {0, 0},                     /* index=109 */
            {0, 0},                     /* index=110 */
            {0, 0},                     /* index=111 */
            {0, 0},                     /* index=112 */
            {0, 0},                     /* index=113 */
            {24, 4},                    /* index=114 Uruk */
            {24, 4},                    /* index=115 */
            {24, 4},                    /* index=116 */
            {24, 4},                    /* index=117 */
            {24, 4},                    /* index=118 */
            {24, 4},                    /* index=119 */
            {0, 0},                     /* index=120 */
            {0, 0},                     /* index=121 */
            {0, 0},                     /* index=122 */
            {0, 0},                     /* index=123 */
            {0, 0},                     /* index=124 */
            {0, 0},                     /* index=125 */
            {32, 4},                    /* index=126 Troll */
            {32, 4},                    /* index=127 */
            {32, 4},                    /* index=128 */
            {32, 4},                    /* index=129 */
            {32, 4},                    /* index=130 */
            {32, 4},                    /* index=131 */
            {24, 4},                    /* index=132 elf woman */
            {24, 4},                    /* index=133 */
            {24, 4},                    /* index=134 */
            {24, 4},                    /* index=135 */
            {24, 4},                    /* index=136 */
            {24, 4},                    /* index=137 */
            {24, 4},                    /* index=138 gollum */
            {24, 4},                    /* index=139 */
            {24, 4},                    /* index=140 */
            {24, 4},                    /* index=141 */
            {24, 4},                    /* index=142 */
            {24, 4},                    /* index=143 */
            {0, 0},                     /* index=144 */
            {0, 0},                     /* index=145 */
            {0, 0},                     /* index=146 */
            {0, 0},                     /* index=147 */
            {0, 0},                     /* index=148 */
            {0, 0},                     /* index=149 */
            {25, 4},                    /* index=150 man in blue */
            {25, 4},                    /* index=151 */
            {25, 4},                    /* index=152 */
            {25, 4},                    /* index=153 */
            {25, 4},                    /* index=154 */
            {25, 4},                    /* index=155 */
            {26, 4},                    /* index=156 Wight */
            {26, 4},                    /* index=157 */
            {26, 4},                    /* index=158 */
            {26, 4},                    /* index=159 */
            {26, 4},                    /* index=160 */
            {26, 4},                    /* index=161 */
            {0, 0},                     /* index=162 */
            {0, 0},                     /* index=163 */
            {0, 0},                     /* index=164 */
            {0, 0},                     /* index=165 */
            {0, 0},                     /* index=166 */
            {0, 0},                     /* index=167 */
            {24, 4},                    /* index=168 tentacles */
            {0, 0},                     /* index=169 */
            {0, 0},                     /* index=170 */
            {0, 0},                     /* index=171 */
            {0, 0},                     /* index=172 */
            {24, 4},                    /* index=173 tentacles */
            {24, 4},                    /* index=174 bird */
            {24, 4},                    /* index=175 */
            {24, 4},                    /* index=176 */
            {24, 4},                    /* index=177 */
            {0, 0},                     /* index=178 */
            {24, 4},                    /* index=179 */
            {0, 0},                     /* index=180 */
            {0, 0},                     /* index=181 */
            {0, 0},                     /* index=182 */
            {0, 0},                     /* index=183 */
            {0, 0},                     /* index=184 */
            {0, 0},                     /* index=185 */
            {32, 4},                    /* index=186 ent */
            {32, 4},                    /* index=187 */
            {32, 4},                    /* index=188 */
            {32, 4},                    /* index=189 */
            {32, 4},                    /* index=190 */
            {32, 4},                    /* index=191 */
            {24, 4},                    /* index=192 woman */
            {24, 4},                    /* index=193 */
            {24, 4},                    /* index=194 */
            {24, 4},                    /* index=195 */
            {24, 4},                    /* index=196 */
            {24, 4},                    /* index=197 */
            {0, 0},                     /* index=198 */
            {0, 0},                     /* index=199 */
            {0, 0},                     /* index=200 */
            {0, 0},                     /* index=201 */
            {0, 0},                     /* index=202 */
            {0, 0},                     /* index=203 */
            {24, 4},                    /* index=204 ghost */
            {24, 4},                    /* index=205 */
            {24, 4},                    /* index=206 */
            {24, 4},                    /* index=207 */
            {24, 4},                    /* index=208 */
            {24, 4},                    /* index=209 */
            {27, 4},                    /* index=210 nazgul */
            {27, 4},                    /* index=211 */
            {27, 4},                    /* index=212 */
            {27, 4},                    /* index=213 */
            {27, 4},                    /* index=214 */
            {27, 4},                    /* index=215 */
            {0, 0},                     /* index=216 */
            {0, 0},                     /* index=217 */
            {0, 0},                     /* index=218 */
            {0, 0},                     /* index=219 */
            {0, 0},                     /* index=220 */
            {49, 1},                    /* index=221 raft */
            {36, 3},                    /* index=222 hand */
            {36, 3},                    /* index=223 */
            {36, 3},                    /* index=224 */
            {36, 3},                    /* index=225 */
            {0, 0},                     /* index=226 */
            {0, 0},                     /* index=227 */
            {36, 3},                    /* index=228 dagger */
            {36, 3},                    /* index=229 */
            {36, 3},                    /* index=230 */
            {36, 3},                    /* index=231 */
            {0, 0},                     /* index=232 */
            {0, 0},                     /* index=233 */
            {36, 4},                    /* index=234 sword */
            {36, 4},                    /* index=235 */
            {36, 4},                    /* index=236 */
            {36, 4},                    /* index=237 */
            {0, 0},                     /* index=238 */
            {0, 0},                     /* index=239 */
            {36, 4},                    /* index=240 staff */
            {36, 4},                    /* index=241 */
            {36, 4},                    /* index=242 */
            {36, 4},                    /* index=243 */
            {0, 0},                     /* index=244 */
            {0, 0},                     /* index=245 */
            {36, 4},                    /* index=246 axe */
            {36, 4},                    /* index=247 */
            {36, 4},                    /* index=248 */
            {36, 4},                    /* index=249 */
            {0, 0},                     /* index=250 */
            {0, 0},                     /* index=251 */
            {36, 4},                    /* index=252 mace */
            {36, 4},                    /* index=253 */
            {36, 4},                    /* index=254 */
            {36, 4},                    /* index=255 */
            {0, 0},                     /* index=256 */
            {0, 0},                     /* index=257 */
            {36, 4},                    /* index=258 club */
            {36, 4},                    /* index=259 */
            {36, 4},                    /* index=260 */
            {36, 4},                    /* index=261 */
            {0, 0},                     /* index=262 */
            {0, 0},                     /* index=263 */
            {0, 0},                     /* index=264 */
            {0, 0},                     /* index=265 */
            {0, 0},                     /* index=266 */
            {0, 0},                     /* index=267 */
            {0, 0},                     /* index=268 */
            {0, 0},                     /* index=269 */
            {36, 3},                    /* index=270 bow */
            {36, 3},                    /* index=271 */
            {36, 3},                    /* index=272 */
            {36, 3},                    /* index=273 */
            {0, 0},                     /* index=274 */
            {0, 0},                     /* index=275 */
            {36, 4},                    /* index=276 torch */
            {36, 4},                    /* index=277 */
            {36, 4},                    /* index=278 */
            {36, 4},                    /* index=279 */
            {0, 0},                     /* index=280 */
            {0, 0},                     /* index=281 */
            {27, 4},                    /* index=282 upper left horse */
            {27, 4},                    /* index=283 */
            {27, 4},                    /* index=284 */
            {27, 4},                    /* index=285 */
            {0, 0},                     /* index=286 */
            {27, 4},                    /* index=287 */
            {27, 4},                    /* index=288 lower right horse */
            {27, 4},                    /* index=289 */
            {27, 4},                    /* index=290 */
            {27, 4},                    /* index=291 */
            {0, 0},                     /* index=292 */
            {27, 4},                    /* index=293 */
            {0, 0},                     /* index=294 */
            {0, 0},                     /* index=295 */
            {0, 0},                     /* index=296 */
            {0, 0},                     /* index=297 */
            {0, 0},                     /* index=298 */
            {0, 0},                     /* index=299 */
            {0, 0},                     /* index=300 */
            {0, 0},                     /* index=301 */
            {0, 0},                     /* index=302 */
            {0, 0},                     /* index=303 */
            {0, 0},                     /* index=304 */
            {0, 0},                     /* index=305 */
            {24, 4},                    /* index=306 girl */
            {24, 4},                    /* index=307 */
            {24, 4},                    /* index=308 */
            {24, 4},                    /* index=309 */
            {0, 0},                     /* index=310 */
            {24, 4},                    /* index=311 */
            {0, 0},                     /* index=312 */
            {0, 0},                     /* index=313 */
            {0, 0},                     /* index=314 */
            {0, 0},                     /* index=315 */
            {0, 0},                     /* index=316 */
            {55, 1},                    /* index=317 door */
            {0, 0},                     /* index=318 */
            {0, 0},                     /* index=319 */
            {0, 0},                     /* index=320 */
            {0, 0},                     /* index=321 */
            {0, 0},                     /* index=322 */
            {0, 0},                     /* index=323 */
            {0, 0},                     /* index=324 */
            {0, 0},                     /* index=325 */
            {0, 0},                     /* index=326 */
            {0, 0},                     /* index=327 */
            {0, 0},                     /* index=328 */
            {0, 0},                     /* index=329 */
            {0, 0},                     /* index=330 */
            {0, 0},                     /* index=331 */
            {0, 0},                     /* index=332 */
            {0, 0},                     /* index=333 */
            {0, 0},                     /* index=334 */
            {27, 4},                    /* index=335 riding hobbit */
            {0, 0},                     /* index=336 */
            {0, 0},                     /* index=337 */
            {0, 0},                     /* index=338 */
            {0, 0},                     /* index=339 */
            {0, 0},                     /* index=340 */
            {0, 0},                     /* index=341 */
            {0, 0},                     /* index=342 */
            {0, 0},                     /* index=343 */
            {0, 0},                     /* index=344 */
            {0, 0},                     /* index=345 */
            {0, 0},                     /* index=346 */
            {0, 0},                     /* index=347 */
            {36, 4},                    /* index=348 goblin sword */
            {36, 4},                    /* index=349 */
            {36, 4},                    /* index=350 */
            {36, 4},                    /* index=351 */
            {0, 0},                     /* index=352 */
            {0, 0},                     /* index=353 */
            {0, 0},                     /* index=354 */
            {0, 0},                     /* index=355 */
            {0, 0},                     /* index=356 */
            {0, 0},                     /* index=357 */
            {0, 0},                     /* index=358 */
            {0, 0},                     /* index=359 */
            {0, 0},                     /* index=360 */
            {0, 0},                     /* index=361 */
            {0, 0},                     /* index=362 */
            {0, 0},                     /* index=363 */
            {0, 0},                     /* index=364 */
            {0, 0},                     /* index=365 */
            {0, 0},                     /* index=366 */
            {0, 0},                     /* index=367 */
            {0, 0},                     /* index=368 */
            {0, 0},                     /* index=369 */
            {0, 0},                     /* index=370 */
            {0, 0},                     /* index=371 */
            {0, 0},                     /* index=372 */
            {0, 0},                     /* index=373 */
            {0, 0},                     /* index=374 */
            {0, 0},                     /* index=375 */
            {0, 0},                     /* index=376 */
            {0, 0},                     /* index=377 */
            {0, 0},                     /* index=378 */
            {0, 0},                     /* index=379 */
            {0, 0},                     /* index=380 */
            {0, 0},                     /* index=381 */
            {0, 0},                     /* index=382 */
            {0, 0},                     /* index=383 */
            {36, 3},                    /* index=384 goblin bow */
            {36, 3},                    /* index=385 */
            {36, 3},                    /* index=386 */
            {36, 3},                    /* index=387 */
            {0, 0},                     /* index=388 */
            {0, 0},                     /* index=389 */
            {0, 0},                     /* index=390 */
            {0, 0},                     /* index=391 */
            {0, 0},                     /* index=392 */
            {0, 0},                     /* index=393 */
            {0, 0},                     /* index=394 */
            {0, 0},                     /* index=395 */
            {36, 3},                    /* index=396 Gollum hand */
            {36, 3},                    /* index=397 */
            {36, 3},                    /* index=398 */
            {36, 3},                    /* index=399 */
            {0, 0},                     /* index=400 */
            {0, 0},                     /* index=401 */
            {36, 3},                    /* index=402 Gollum dagger */
            {36, 3},                    /* index=403 */
            {36, 3},                    /* index=404 */
            {36, 3},                    /* index=405 */
            {0, 0},                     /* index=406 */
            {0, 0},                     /* index=407 */
            {36, 4},                    /* index=408 Gollum sword */
            {36, 4},                    /* index=409 */
            {36, 4},                    /* index=410 */
            {36, 4},                    /* index=411 */
            {0, 0},                     /* index=412 */
            {0, 0},                     /* index=413 */
            {36, 4},                    /* index=414 Gollum staff */
            {36, 4},                    /* index=415 */
            {36, 4},                    /* index=416 */
            {36, 4},                    /* index=417 */
            {0, 0},                     /* index=418 */
            {0, 0},                     /* index=419 */
            {36, 4},                    /* index=420 Gollum axe */
            {36, 4},                    /* index=421 */
            {36, 4},                    /* index=422 */
            {36, 4},                    /* index=423 */
            {0, 0},                     /* index=424 */
            {0, 0},                     /* index=425 */
            {36, 4},                    /* index=426 Gollum mace */
            {36, 4},                    /* index=427 */
            {36, 4},                    /* index=428 */
            {36, 4},                    /* index=429 */
            {0, 0},                     /* index=430 */
            {0, 0},                     /* index=431 */
            {36, 4},                    /* index=432 Gollum club */
            {36, 4},                    /* index=433 */
            {36, 4},                    /* index=434 */
            {36, 4},                    /* index=435 */
            {0, 0},                     /* index=436 */
            {0, 0},                     /* index=437 */
            {0, 0},                     /* index=438 */
            {0, 0},                     /* index=439 */
            {0, 0},                     /* index=440 */
            {0, 0},                     /* index=441 */
            {0, 0},                     /* index=442 */
            {0, 0},                     /* index=443 */
            {36, 3},                    /* index=444 Gollum bow */
            {36, 3},                    /* index=445 */
            {36, 3},                    /* index=446 */
            {36, 3},                    /* index=447 */
            {0, 0},                     /* index=448 */
            {0, 0},                     /* index=449 */
            {36, 4},                    /* index=450 Gollum torch */
            {36, 4},                    /* index=451 */
            {36, 4},                    /* index=452 */
            {36, 4},                    /* index=453 */
            {0, 0},                     /* index=454 */
            {0, 0},                     /* index=455 */
            {0, 0},                     /* index=456 */
            {0, 0},                     /* index=457 */
            {0, 0},                     /* index=458 */
            {0, 0},                     /* index=459 */
            {0, 0},                     /* index=460 */
            {0, 0},                     /* index=461 */
            {0, 0},                     /* index=462 */
            {0, 0},                     /* index=463 */
            {0, 0},                     /* index=464 */
            {0, 0},                     /* index=465 */
            {0, 0},                     /* index=466 */
            {0, 0},                     /* index=467 */
            {0, 0},                     /* index=468 */
            {0, 0},                     /* index=469 */
            {0, 0},                     /* index=470 */
            {0, 0},                     /* index=471 */
            {0, 0},                     /* index=472 */
            {0, 0},                     /* index=473 */
            {0, 0},                     /* index=474 */
            {0, 0},                     /* index=475 */
            {0, 0},                     /* index=476 */
            {0, 0},                     /* index=477 */
            {0, 0},                     /* index=478 */
            {0, 0},                     /* index=479 */
            {0, 0},                     /* index=480 */
            {0, 0},                     /* index=481 */
            {0, 0},                     /* index=482 */
            {0, 0},                     /* index=483 */
            {0, 0},                     /* index=484 */
            {0, 0},                     /* index=485 */
            {36, 4},                    /* index=486 troll mace */
            {36, 4},                    /* index=487 */
            {36, 4},                    /* index=488 */
            {36, 4},                    /* index=489 */
            {0, 0},                     /* index=490 */
            {0, 0},                     /* index=491 */
            {36, 4},                    /* index=492 troll club */
            {36, 4},                    /* index=493 */
            {36, 4},                    /* index=494 */
            {36, 4},                    /* index=495 */
            {0, 0},                     /* index=496 */
            {0, 0},                     /* index=497 */
            {0, 0},                     /* index=498 */
            {0, 0},                     /* index=499 */
            {0, 0},                     /* index=500 */
            {0, 0},                     /* index=501 */
            {0, 0},                     /* index=502 */
            {0, 0},                     /* index=503 */
            {0, 0},                     /* index=504 */
            {0, 0},                     /* index=505 */
            {0, 0},                     /* index=506 */
            {0, 0},                     /* index=507 */
            {0, 0},                     /* index=508 */
            {0, 0},                     /* index=509 */
            {0, 0},                     /* index=510 */
            {0, 0},                     /* index=511 */
            {0, 0},                     /* index=512 */
            {0, 0},                     /* index=513 */
            {0, 0},                     /* index=514 */
            {0, 0},                     /* index=515 */
            {0, 0},                     /* index=516 */
            {0, 0},                     /* index=517 */
            {0, 0},                     /* index=518 */
            {0, 0},                     /* index=519 */
            {0, 0},                     /* index=520 */
            {0, 0},                     /* index=521 */
            {0, 0},                     /* index=522 */
            {0, 0},                     /* index=523 */
            {0, 0},                     /* index=524 */
            {0, 0},                     /* index=525 */
            {0, 0},                     /* index=526 */
            {0, 0},                     /* index=527 */
            {36, 4},                    /* index=528 ghost sword */
            {36, 4},                    /* index=529 */
            {36, 4},                    /* index=530 */
            {36, 4},                    /* index=531 */
            {0, 0},                     /* index=532 */
            {0, 0},                     /* index=533 */
            {0, 0},                     /* index=534 */
            {0, 0},                     /* index=535 */
            {0, 0},                     /* index=536 */
            {0, 0},                     /* index=537 */
            {0, 0},                     /* index=538 */
            {0, 0},                     /* index=539 */
            {0, 0},                     /* index=540 */
            {0, 0},                     /* index=541 */
            {0, 0},                     /* index=542 */
            {0, 0},                     /* index=543 */
            {0, 0},                     /* index=544 */
            {0, 0},                     /* index=545 */
            {0, 0},                     /* index=546 */
            {0, 0},                     /* index=547 */
            {0, 0},                     /* index=548 */
            {0, 0},                     /* index=549 */
            {0, 0},                     /* index=550 */
            {0, 0},                     /* index=551 */
            {0, 0},                     /* index=552 */
            {0, 0},                     /* index=553 */
            {0, 0},                     /* index=554 */
            {0, 0},                     /* index=555 */
            {0, 0},                     /* index=556 */
            {0, 0},                     /* index=557 */
            {0, 0},                     /* index=558 */
            {0, 0},                     /* index=559 */
            {0, 0},                     /* index=560 */
            {0, 0},                     /* index=561 */
            {0, 0},                     /* index=562 */
            {0, 0},                     /* index=563 */
            {0, 0},                     /* index=564 */
            {0, 0},                     /* index=565 */
            {0, 0},                     /* index=566 */
            {0, 0},                     /* index=567 */
            {0, 0},                     /* index=568 */
            {0, 0},                     /* index=569 */
            {0, 0},                     /* index=570 */
            {0, 0},                     /* index=571 */
            {0, 0},                     /* index=572 */
            {0, 0},                     /* index=573 */
            {0, 0},                     /* index=574 */
            {0, 0},                     /* index=575 */
            {36, 4},                    /* index=576 ent hand */
            {36, 4},                    /* index=577 */
            {36, 4},                    /* index=578 */
            {0, 0},                     /* index=579 */
            {0, 0},                     /* index=580 */
            {0, 0},                     /* index=581 */
            {0, 0},                     /* index=582 */
            {0, 0},                     /* index=583 */
            {0, 0},                     /* index=584 */
            {0, 0},                     /* index=585 */
            {0, 0},                     /* index=586 */
            {32, 4},                    /* index=587 explosion */
            {0, 0},                     /* index=588 */
            {0, 0},                     /* index=589 */
            {0, 0},                     /* index=590 */
            {0, 0},                     /* index=591 */
            {0, 0},                     /* index=592 */
            {0, 0},                     /* index=593 */
            {0, 0},                     /* index=594 */
            {0, 0},                     /* index=595 */
            {0, 0},                     /* index=596 */
            {0, 0},                     /* index=597 */
            {0, 0},                     /* index=598 */
            {0, 0},                     /* index=599 */
            {0, 0},                     /* index=600 */
            {0, 0},                     /* index=601 */
            {0, 0},                     /* index=602 */
            {0, 0},                     /* index=603 */
            {0, 0},                     /* index=604 */
            {0, 0},                     /* index=605 */
            {0, 0},                     /* index=606 */
            {0, 0},                     /* index=607 */
            {0, 0},                     /* index=608 */
            {0, 0},                     /* index=609 */
            {0, 0},                     /* index=610 */
            {0, 0},                     /* index=611 */
            {0, 0},                     /* index=612 */
            {0, 0},                     /* index=613 */
            {0, 0},                     /* index=614 */
            {0, 0},                     /* index=615 */
            {0, 0},                     /* index=616 */
            {0, 0},                     /* index=617 */
            {0, 0},                     /* index=618 */
            {0, 0},                     /* index=619 */
            {0, 0},                     /* index=620 */
            {0, 0},                     /* index=621 */
            {0, 0},                     /* index=622 */
            {0, 0},                     /* index=623 */
            {0, 0},                     /* index=624 */
            {0, 0},                     /* index=625 */
            {0, 0},                     /* index=626 */
            {0, 0},                     /* index=627 */
            {0, 0},                     /* index=628 */
            {0, 0},                     /* index=629 */
            {0, 0},                     /* index=630 */
            {0, 0},                     /* index=631 */
            {0, 0},                     /* index=632 */
            {0, 0},                     /* index=633 */
            {0, 0},                     /* index=634 */
            {0, 0},                     /* index=635 */
            {0, 0},                     /* index=636 */
            {0, 0},                     /* index=637 */
            {0, 0},                     /* index=638 */
            {0, 0},                     /* index=639 */
            {0, 0},                     /* index=640 */
            {0, 0},                     /* index=641 */
            {0, 0},                     /* index=642 */
            {0, 0},                     /* index=643 */
            {0, 0},                     /* index=644 */
            {0, 0},                     /* index=645 */
            {0, 0},                     /* index=646 */
            {0, 0},                     /* index=647 */
            {0, 0},                     /* index=648 */
            {0, 0},                     /* index=649 */
            {0, 0},                     /* index=650 */
            {0, 0},                     /* index=651 */
            {0, 0},                     /* index=652 */
            {0, 0},                     /* index=653 */
            {0, 0},                     /* index=654 */
            {0, 0},                     /* index=655 */
            {0, 0},                     /* index=656 */
            {0, 0},                     /* index=657 */
            {0, 0},                     /* index=658 */
            {0, 0},                     /* index=659 */
            {0, 0},                     /* index=660 */
            {0, 0},                     /* index=661 */
            {0, 0},                     /* index=662 */
            {0, 0},                     /* index=663 */
            {0, 0},                     /* index=664 */
            {0, 0},                     /* index=665 */
            {0, 0},                     /* index=666 */
            {0, 0},                     /* index=667 */
            {0, 0},                     /* index=668 */
            {0, 0},                     /* index=669 */
            {0, 0},                     /* index=670 */
            {0, 0},                     /* index=671 */
            {0, 0},                     /* index=672 */
            {0, 0},                     /* index=673 */
            {0, 0},                     /* index=674 */
            {0, 0},                     /* index=675 */
            {0, 0},                     /* index=676 */
            {0, 0},                     /* index=677 */
            {0, 0},                     /* index=678 */
            {0, 0},                     /* index=679 */
            {0, 0},                     /* index=680 */
            {0, 0},                     /* index=681 */
            {0, 0},                     /* index=682 */
            {0, 0},                     /* index=683 */
            {0, 0},                     /* index=684 */
            {0, 0},                     /* index=685 */
            {0, 0},                     /* index=686 */
            {0, 0},                     /* index=687 */
            {0, 0},                     /* index=688 */
            {0, 0},                     /* index=689 */
            {0, 0},                     /* index=690 */
            {0, 0},                     /* index=691 */
            {0, 0},                     /* index=692 */
            {0, 0},                     /* index=693 */
            {0, 0},                     /* index=694 */
            {0, 0},                     /* index=695 */
            {0, 0},                     /* index=696 */
            {0, 0},                     /* index=697 */
            {0, 0},                     /* index=698 */
            {0, 0}                      /* index=699 */
};           
        // Default constructor.
        public Shape()
        {

        }
        // Constructor with index.
        public Shape(int index)
        {
            pixmaps_num = shapes_param[index, 1];
            pixmaps = new Pixmap[4];
        }



        // ToDo Combine GetShapePalette with GetPalette in the Palette Class
        public static Palette GetShapePalette()
        {
            Palette result;
            byte[] PalDat;
            Archive.FileDetails pal;
            Config cfg = new Config(true);
            pal.Filename = "SHAPES";
            pal.Path = cfg.GameDirectory;
            pal.Suffix = "PAL";
            pal.FullName = string.Concat(pal.Path, "\\", pal.Filename, ".", pal.Suffix);
            FileInfo p1 = new FileInfo(pal.FullName);
            pal.Size = (int)p1.Length;
            PalDat = File.ReadAllBytes(pal.FullName);

            result = new Palette(PalDat);
            if (pal.Size != PalDat.Length)
            {
                MessageBox.Show("lotr: shapes.pal is not a valid palette file.", "ShapesInit Palette size error!");
            }
            return result;
        }

        public static Shape Get_Shape(int index)
        {
            int i = index;
            
            int size = 0;
            Archive archive= Archive.NDXOpen("SHAPES");
            
            Shape t_shape;
            byte[] data;
            if (Archive.ArchiveDatasize(archive, i) == 0 || shapes_param[i, 0] == 0)
                return null;
            else
            {
                data = Archive.decompressNDXArchive(archive, i, ref size);
                t_shape = new Shape();
                t_shape.w = shapes_param[i, 0];
                t_shape.h = size / shapes_param[i, 0] / shapes_param[i, 1];
                t_shape.shapePixmap = data;
                t_shape.pixmaps_num = shapes_param[i, 1];
            }
            return t_shape;
        }


        // ShapeInit
        // Initializes shapes for the game.
        public static List<Shape> ShapeInit()
        {
            // VARIABLE DECLARATIONS:
            int size = 0;
            int w, h;
            int i, j;

            // COLLECTIONS, LISTS, ARRAY DECLARATIONS:
            List<Shape> ShapeCache = new List<Shape>();
            byte[] data;

            // OBJECT DECLARATIONS:
            Archive archive;
            Pixmap pixmap;
           
            archive = Archive.NDXOpen("SHAPES");
            for(i=0; i < archive.Size; i++)
            {
                if (Archive.ArchiveDatasize(archive, i) == 0 || shapes_param[i, 0] == 0)
                    ShapeCache.Add(null);
                else
                {
                    data = Archive.decompressNDXArchive(archive, i, ref size);
                    Shape t_shape = new Shape(i);

                    w = shapes_param[i, 0];
                    h = size / shapes_param[i, 0] / shapes_param[i, 1];
                    t_shape.shapePixmap = data;
                    for (j = 0; j < 4; ++j)
                        t_shape.pixmaps[j] = null;
                    t_shape.pixmaps_num = shapes_param[i, 1];

                    for (j = 0; j < t_shape.pixmaps_num; ++j)
                    {
                        pixmap = new Pixmap(w,h);
                        //C Original -- void *memcpy(void *dest, const void * src, size_t n)
                        //
                        //memcpy(pixmap->data, data + j * w * h, w*h);
                        //
                        //C# Translation --
                        //public static void BlockCopy(Array src, int srcOffset, Array dst, int dstOffset, int count);
                        Buffer.BlockCopy(data, j * w * h, pixmap.data, 0, w * h);
                        
                        string filename1 = "shape";
                        string filename2 = i.ToString();
                        string filename3 = j.ToString();
                        string full = string.Concat(filename1, filename2, "_", filename3, ".SHP");
                        using (var fs = new FileStream(full, FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(pixmap.data, 0, pixmap.data.Length);
                        }


                        t_shape.pixmaps[j] = pixmap;
                    }
                    ShapeCache.Add(t_shape);
                }
            }
            return ShapeCache;
        }
    }




    

}
