import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Header from './BlogManage/components/Header/Header';
import Homepage from './BlogManage/pages/Homepage/Homepage';
import './App.less';

class App extends Component {
    render() {
        return (
            <div className='app'>
                <Router>
                    <Header />
                    <Switch>
                        <Route exact path="/" component={Homepage} />
                    </Switch>
                </Router>
            </div>
        );
    }
}

export default App;
