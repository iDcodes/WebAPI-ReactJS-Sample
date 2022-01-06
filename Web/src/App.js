import logo from './logo.svg';
import './App.css';

import { Home } from './components/home.component';
import { Department } from './components/department.component';
import { Employee } from './components/employee.component';
import { Navigation } from './components/navigation.component';

import { BrowserRouter, Route, Switch } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <h3 className="m-3 d-flex justify-content-center">
          React JS Tutorial
        </h3>

        <Navigation/>

        <Switch>
          <Route path="/" component={Home} exact />
          <Route path="/department" component={Department} />
          <Route path="/employee" component={Employee} />
        </Switch>
      </div>
    </BrowserRouter>
  );
}

export default App;
