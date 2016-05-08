﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MathTeacher.DAL;
using MathTeacher.Models;

namespace MathTeacher.Controllers
{
    public class GameController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Game
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModel gameModel = db.Games.Find(id);
            if (gameModel == null)
            {
                return HttpNotFound();
            }
            return View(gameModel);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] GameModel gameModel)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(gameModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameModel);
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModel gameModel = db.Games.Find(id);
            if (gameModel == null)
            {
                return HttpNotFound();
            }
            return View(gameModel);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] GameModel gameModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameModel);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameModel gameModel = db.Games.Find(id);
            if (gameModel == null)
            {
                return HttpNotFound();
            }
            return View(gameModel);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameModel gameModel = db.Games.Find(id);
            db.Games.Remove(gameModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}