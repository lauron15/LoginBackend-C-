import { Counter } from "./components/Counter";
import CounterState from "./components/CounterState";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <CounterState />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
