var D = Object.defineProperty;
var a = (e, t) => D(e, "name", { value: t, configurable: !0 });
var m, h, C, S, f = /* @__PURE__ */ a(function(e, t) {
  return { name: e, value: t === void 0 ? -1 : t, delta: 0, entries: [], id: "v1-".concat(Date.now(), "-").concat(Math.floor(8999999999999 * Math.random()) + 1e12) };
}, "a"), y = /* @__PURE__ */ a(function(e, t) {
  try {
    if (PerformanceObserver.supportedEntryTypes.includes(e)) {
      if (e === "first-input" && !("PerformanceEventTiming" in self))
        return;
      var i = new PerformanceObserver(function(r) {
        return r.getEntries().map(t);
      });
      return i.observe({ type: e, buffered: !0 }), i;
    }
  } catch {
  }
}, "r"), E = /* @__PURE__ */ a(function(e, t) {
  var i = /* @__PURE__ */ a(function r(n) {
    n.type !== "pagehide" && document.visibilityState !== "hidden" || (e(n), t && (removeEventListener("visibilitychange", r, !0), removeEventListener("pagehide", r, !0)));
  }, "n");
  addEventListener("visibilitychange", i, !0), addEventListener("pagehide", i, !0);
}, "o"), g = /* @__PURE__ */ a(function(e) {
  addEventListener("pageshow", function(t) {
    t.persisted && e(t);
  }, !0);
}, "c"), v = typeof WeakSet == "function" ? /* @__PURE__ */ new WeakSet() : /* @__PURE__ */ new Set(), p = /* @__PURE__ */ a(function(e, t, i) {
  var r;
  return function() {
    t.value >= 0 && (i || v.has(t) || document.visibilityState === "hidden") && (t.delta = t.value - (r || 0), (t.delta || r === void 0) && (r = t.value, e(t)));
  };
}, "f"), I = /* @__PURE__ */ a(function(e, t) {
  var i, r = f("CLS", 0), n = /* @__PURE__ */ a(function(o) {
    o.hadRecentInput || (r.value += o.value, r.entries.push(o), i());
  }, "u"), c = y("layout-shift", n);
  c && (i = p(e, r, t), E(function() {
    c.takeRecords().map(n), i();
  }), g(function() {
    r = f("CLS", 0), i = p(e, r, t);
  }));
}, "s"), d = -1, w = /* @__PURE__ */ a(function() {
  return document.visibilityState === "hidden" ? 0 : 1 / 0;
}, "p"), b = /* @__PURE__ */ a(function() {
  E(function(e) {
    var t = e.timeStamp;
    d = t;
  }, !0);
}, "v"), L = /* @__PURE__ */ a(function() {
  return d < 0 && (d = w(), b(), g(function() {
    setTimeout(function() {
      d = w(), b();
    }, 0);
  })), { get timeStamp() {
    return d;
  } };
}, "d"), R = /* @__PURE__ */ a(function(e, t) {
  var i, r = L(), n = f("FCP"), c = /* @__PURE__ */ a(function(s) {
    s.name === "first-contentful-paint" && (u && u.disconnect(), s.startTime < r.timeStamp && (n.value = s.startTime, n.entries.push(s), v.add(n), i()));
  }, "s"), o = performance.getEntriesByName("first-contentful-paint")[0], u = o ? null : y("paint", c);
  (o || u) && (i = p(e, n, t), o && c(o), g(function(s) {
    n = f("FCP"), i = p(e, n, t), requestAnimationFrame(function() {
      requestAnimationFrame(function() {
        n.value = performance.now() - s.timeStamp, v.add(n), i();
      });
    });
  }));
}, "l"), l = { passive: !0, capture: !0 }, q = new Date(), F = /* @__PURE__ */ a(function(e, t) {
  m || (m = t, h = e, C = new Date(), k(removeEventListener), P());
}, "y"), P = /* @__PURE__ */ a(function() {
  if (h >= 0 && h < C - q) {
    var e = { entryType: "first-input", name: m.type, target: m.target, cancelable: m.cancelable, startTime: m.timeStamp, processingStart: m.timeStamp + h };
    S.forEach(function(t) {
      t(e);
    }), S = [];
  }
}, "g"), A = /* @__PURE__ */ a(function(e) {
  if (e.cancelable) {
    var t = (e.timeStamp > 1e12 ? new Date() : performance.now()) - e.timeStamp;
    e.type == "pointerdown" ? function(i, r) {
      var n = /* @__PURE__ */ a(function() {
        F(i, r), o();
      }, "n"), c = /* @__PURE__ */ a(function() {
        o();
      }, "i"), o = /* @__PURE__ */ a(function() {
        removeEventListener("pointerup", n, l), removeEventListener("pointercancel", c, l);
      }, "a");
      addEventListener("pointerup", n, l), addEventListener("pointercancel", c, l);
    }(t, e) : F(t, e);
  }
}, "E"), k = /* @__PURE__ */ a(function(e) {
  ["mousedown", "keydown", "touchstart", "pointerdown"].forEach(function(t) {
    return e(t, A, l);
  });
}, "w"), M = /* @__PURE__ */ a(function(e, t) {
  var i, r = L(), n = f("FID"), c = /* @__PURE__ */ a(function(u) {
    u.startTime < r.timeStamp && (n.value = u.processingStart - u.startTime, n.entries.push(u), v.add(n), i());
  }, "l"), o = y("first-input", c);
  i = p(e, n, t), o && E(function() {
    o.takeRecords().map(c), o.disconnect();
  }, !0), o && g(function() {
    var u;
    n = f("FID"), i = p(e, n, t), S = [], h = -1, m = null, k(addEventListener), u = c, S.push(u), P();
  });
}, "L"), O = /* @__PURE__ */ a(function(e, t) {
  var i, r = L(), n = f("LCP"), c = /* @__PURE__ */ a(function(s) {
    var T = s.startTime;
    T < r.timeStamp && (n.value = T, n.entries.push(s)), i();
  }, "m"), o = y("largest-contentful-paint", c);
  if (o) {
    i = p(e, n, t);
    var u = /* @__PURE__ */ a(function() {
      v.has(n) || (o.takeRecords().map(c), o.disconnect(), v.add(n), i());
    }, "v");
    ["keydown", "click"].forEach(function(s) {
      addEventListener(s, u, { once: !0, capture: !0 });
    }), E(u, !0), g(function(s) {
      n = f("LCP"), i = p(e, n, t), requestAnimationFrame(function() {
        requestAnimationFrame(function() {
          n.value = performance.now() - s.timeStamp, v.add(n), i();
        });
      });
    });
  }
}, "T"), x = /* @__PURE__ */ a(function(e) {
  var t, i = f("TTFB");
  t = /* @__PURE__ */ a(function() {
    try {
      var r = performance.getEntriesByType("navigation")[0] || function() {
        var n = performance.timing, c = { entryType: "navigation", startTime: 0 };
        for (var o in n)
          o !== "navigationStart" && o !== "toJSON" && (c[o] = Math.max(n[o] - n.navigationStart, 0));
        return c;
      }();
      if (i.value = i.delta = r.responseStart, i.value < 0)
        return;
      i.entries = [r], e(i);
    } catch {
    }
  }, "t"), document.readyState === "complete" ? setTimeout(t, 0) : addEventListener("pageshow", t);
}, "b");
export {
  I as getCLS,
  R as getFCP,
  M as getFID,
  O as getLCP,
  x as getTTFB
};
//# sourceMappingURL=web-vitals.65b9a061.mjs.map
