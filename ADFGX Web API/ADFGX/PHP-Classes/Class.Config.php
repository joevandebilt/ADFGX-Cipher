<?php

class Config {
	
	/**
	* @var string Full initialization file path.
	* @access private
	*/
	var $_path = "modules/param.ini";
	
	/**
	* @var array string ini-file data (first column = ini-file section, second column = ini-file section's key)
	* @access private
	*/
	var $VARS = array();
		
	/**
	* @var int Error count
	* @access private
	*/
	var $_errorCount = 0;
	
	/**
     * Get Error count
     *
     * @return     int Number of error since last load
     * @access     public
     */
    function getErrorCount()
    {
        return $this->_errorCount;

    } // end function
    
    /**
	* @desc					  Retrieves the value for a given key.
	* @param  string $key     Key or name of directive to get in current config.
	* @param  string $section Name of section to get key/value-pair therein.
	* @return mixed           Returns the string value or empty string on failure.
	* @access public
	*/
	function getIniParameter($key='', $section=''){
		// Init.
		$toReturn = '';
		
		// Check parameter
		if ($key != '' && $section != '') {			
			// Get requested value
			$toReturn =  $this->VARS[$section][$key];
		}
				
		// If value was not found (false), return NULL
		if ($toReturn===false) {
			$toReturn = '';
		} 
		$toReturn =  $this->VARS[$section][$key];
		return ($toReturn);
	} // end function
    
	/**
     * Get ini-file path
     *
     * @return     string Ini-file path
     * @access     public
     */
    function getPath()
    {
        return $this->_path;

    } // end function

     /**
     * Set ini-file path
     *
     * @param	   string $value Ini-file path
     * @return     bool Affectation's result.
     * @access     public
     */
    function setPath($value)
    {
        return $this->_path = $value;

    } // end function

	/**
	* @desc   Default constructor.
	* @param  string $path Path to ini-file to load at startup.
	* NOTE:   If the ini-file can not be found, or if $path is not given
	*		  try to use the default ini-file.
	* @return void Returns nothing.
	* @access public
	*/
	function __construct($path = null){
		// Check parameter
		if ($path == null) {
			$this->load($this->_path);
		} else {
			$this->load($path);
		}
	}

	/**
	* @desc   Loads and parses ini-file from filesystem.
	* @param  string $path Optional path to ini-file to load.
	* NOTE:   When not provided, default class-var path will be used.
	* @return bool Returns TRUE on success, FALSE on failure.
	* @access public
	*/
	function load($path=null){
		
		// If path was specified, check if valid else abort
		if ($path!=null) {
			if (!is_file($path)) {
				// File not found
				$this->_errorCount++;
				return false;
			} else {
				// File exist
				$this->_path = $path;
				$this->_errorCount = 0;
			}
		} else {
			// No path was specified, fall back to class-var
			if (!is_file($this->_path)) {
				// File not found
				$this->_errorCount++;
				return false;
			} else {
				$this->_errorCount = 0;
			}
		}
		
		/* 
		 * PHP's own method is used for parsing the ini-file instead of own code. 
		 * It's robust enough ;-)
		 */
		$this->VARS = parse_ini_file($path, true);
		return true;
	}
}
?>
