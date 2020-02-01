//eslint-disable-next-line
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import React, { Suspense, lazy } from "react";

const HomePage = lazy(() => import("../Container/Home/Home"));
const Insurance = lazy(() => import("../Container/Insurance/Insurance"));

const Routers = () => (
  <Suspense fallback={<div>Loading...</div>}>
    <Switch>
      <Route path="/" component={HomePage} exact />
      <Route path="/insurance" component={Insurance} exact />
    </Switch>
  </Suspense>
);

export default Routers;
