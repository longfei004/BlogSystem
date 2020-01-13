import React from 'react';
import { Icon } from 'antd';
import UserLogo from '../../../assets/avatar.jpg';
import './Header.less';

const Header = () => {
    return (
        <div className='header'>
            <div className='header-container'>
                <p className='title'>Erer</p>
                <nav className='navigation'>
                    <img className='user-logo' src={UserLogo} alt='This image is not exist!'/>
                    <Icon type="caret-down" />
                </nav>
            </div>
        </div>
    )
}

export default Header;