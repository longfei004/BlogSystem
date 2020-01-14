import React, { Component } from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import { Route, Switch } from 'react-router';
import Header from './BlogManage/components/Header/Header';
import Homepage from './BlogManage/pages/Homepage/Homepage';
import BlogDetail from './BlogManage/pages/BlogDetail/BlogDetail';
import './App.less';

class App extends Component {
    render() {
        return (
            <Router>
                <div className='app'>
                    <Header />
                    <div className='page-container'>
                        <Switch>
                            <Route exact path='/blog/:id' component={BlogDetail} />
                            <Route exact path='/' component={Homepage} />
                        </Switch>
                    </div>
                </div>
            </Router >
        );
    }
}

export default App;
